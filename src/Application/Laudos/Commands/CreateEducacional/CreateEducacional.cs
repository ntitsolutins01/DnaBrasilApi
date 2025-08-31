using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

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

        var respostaIds = request.Respostas
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(s => int.TryParse(s, out var id) ? id : 0)
            .Where(id => id > 0)
            .Distinct()
            .ToList();

        var respostas = await _context.Respostas
            .Where(r => respostaIds.Contains(r.Id))
            .ToListAsync(cancellationToken);

        int PointsFor(Resposta r) => r.ValorPesoResposta switch
        {
            1 => 10,   // Nível 1
            2 => 30,   // Nível 2
            3 => 50,   // Nível 3
            _ => 0     // Errada
        };

        var n1 = respostas.Count(r => r.ValorPesoResposta == 1);
        var n2 = respostas.Count(r => r.ValorPesoResposta == 2);
        var n3 = respostas.Count(r => r.ValorPesoResposta == 3);

        var totalScore = respostas.Sum(PointsFor);

        int encaminhamentoId;
        if (totalScore >= 220 && totalScore <= 450 && (n1 + n2) >= 3 && n3 >= 2)
        {
            encaminhamentoId = 98; // Adequado
        }
        else if (totalScore >= 120 && totalScore <= 219 && (n1 + n2) >= 3)
        {
            encaminhamentoId = 97; // Intermediário
        }
        else
        {
            encaminhamentoId = 96; // Defasagem
        }

        var encaminhamento = await _context.Encaminhamentos.FindAsync([encaminhamentoId], cancellationToken);
        Guard.Against.NotFound(encaminhamentoId, encaminhamento);

        var entity = new Educacional
        {
            Profissional = profissional,
            Aluno = aluno,
            Respostas = string.Join(",", respostas.Select(r => r.Id)),
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
