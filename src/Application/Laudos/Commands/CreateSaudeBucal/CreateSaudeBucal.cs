using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateSaudeBucal;

public record CreateSaudeBucalCommand : IRequest<int>
{
    public required int ProfissionalId { get; init; }
    public required int AlunoId { get; init; }
    public required string Respostas { get; init; }
    public required string StatusSaudeBucal { get; init; }
}

public class CreateSaudeBucalCommandHandler : IRequestHandler<CreateSaudeBucalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos.FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync([request.ProfissionalId], cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        var entity = new SaudeBucal
        {
            Profissional = profissional,
            Aluno = aluno,
            Respostas = request.Respostas,
            StatusSaudeBucal = request.StatusSaudeBucal,
            Encaminhamento = GetEncaminhamento(request.Respostas)
        };

        _context.SaudeBucais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    private Encaminhamento? GetEncaminhamento(string strRespostas)
    {
        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.SaudeBucal);

        decimal quadrante1;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.SaudeBucal).ToList();

        List<int> listRespostas = strRespostas.Split(',').Select(item => int.Parse(item)).ToList();

        var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

        quadrante1 = respostas.Where(x => x.Questionario.Quadrante == 1).Sum(s => s.ValorPesoResposta);

        var result = metricas.Find(
            delegate (TextoLaudo item)
            {
                return quadrante1 >= item.PontoInicial && quadrante1 <= item.PontoFinal && item.Quadrante == 1;
            }
        );

        if (result == null)
        {
            return null;
        }

        var parametro = result.Aviso.Split('.').First();

        var encaminhamentoSaudeBucal = encaminhamentos.First(x => x.Parametro == parametro);

        return encaminhamentoSaudeBucal;
    }
}
