using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateEducacional;

public record CreateEducacionalCommand : IRequest<int>
{
    public required int ProfissionalId { get; init; }
    public required int AlunoId { get; init; }
    public required string Gabarito { get; init; }
    public required string Respostas { get; init; } 
    public string? Imagem { get; init; }
    public string? NomeImagem { get; init; }
    public required string StatusEducacional { get; init; }
}

public class CreateEducacionalCommandHandler : IRequestHandler<CreateEducacionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEducacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEducacionalCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos.FindAsync([request.AlunoId], cancellationToken);
        Guard.Against.NotFound(request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync([request.ProfissionalId], cancellationToken);
        Guard.Against.NotFound(request.ProfissionalId, profissional);

        var idsNaOrdem = request.Respostas
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(s => int.TryParse(s, out var id) ? id : 0)
            .ToList();

        var idsValidos = idsNaOrdem.Where(id => id > 0).Distinct().ToList();

        var respostasPorId = await _context.Respostas
            .Where(r => idsValidos.Contains(r.Id))
            .ToDictionaryAsync(r => r.Id, cancellationToken);

        var respostas = idsNaOrdem
            .Select(id => id == 0
                ? null
                : (respostasPorId.TryGetValue(id, out var r) ? r : null))
            .ToList();

        var respostasIdsNormalizados = idsNaOrdem
            .Select(id => id == 0 ? 0 : (respostasPorId.ContainsKey(id) ? id : 0))
            .ToList();

        static int PointsFor(Resposta? r) => r?.ValorPesoResposta switch
        {
            1 => 10,   // Nível 1
            2 => 30,   // Nível 2
            3 => 50,   // Nível 3
            _ => 0     // Errada ou null
        };

        var n1 = respostas.Count(r => r?.ValorPesoResposta == 1);
        var n2 = respostas.Count(r => r?.ValorPesoResposta == 2);
        var n3 = respostas.Count(r => r?.ValorPesoResposta == 3);

        var totalScore = respostas.Sum(PointsFor);

        int encaminhamentoId;

        // Regra 1: até 2 acertos de peso 1 -> Defasagem
        if (n1 <= 2)
        {
            encaminhamentoId = 96; // Defasagem
        }
        // Regra 2: mais de 3 acertos de peso 1, mas até 2 de peso 2 -> Defasagem
        else if (n2 <= 2)
        {
            encaminhamentoId = 96; // Defasagem
        }
        // Regras 3, 4 e 5: com >=3 em peso 1 e >=3 em peso 2,
        // a decisão depende do peso 3
        else
        {
            if (n3 >= 2)
                encaminhamentoId = 98; // Adequado
            else
                // n3 == 0 ou 1 -> Intermediário (cobre regras 3 e 4)
                encaminhamentoId = 97; // Intermediário
        }

        var encaminhamento = await _context.Encaminhamentos.FindAsync([encaminhamentoId], cancellationToken);
        Guard.Against.NotFound(encaminhamentoId, encaminhamento);

        var entity = new Educacional
        {
            Profissional = profissional,
            Aluno = aluno,
            Respostas = string.Join(",", respostasIdsNormalizados),
            StatusEducacional = request.StatusEducacional,
            Gabarito = request.Gabarito.Contains("Educacional")
                ? request.Gabarito.Split("Educacional", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).LastOrDefault() ?? request.Gabarito
                : request.Gabarito,
            Encaminhamento = encaminhamento,
            Imagem = request.Imagem,
            NomeImagem = request.NomeImagem
        };

        _context.Educacionais.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
