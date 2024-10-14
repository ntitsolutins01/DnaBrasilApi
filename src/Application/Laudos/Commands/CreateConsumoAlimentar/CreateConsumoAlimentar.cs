using System.Threading;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateConsumoAlimentar;

public record CreateConsumoAlimentarCommand : IRequest<int>
{
    public int ProfissionalId { get; init; }
    public int AlunoId { get; init; }
    public required string Respostas { get; init; }
    public required string StatusConsumoAlimentar { get; init; }
}

public class CreateConsumoAlimentarCommandHandler : IRequestHandler<CreateConsumoAlimentarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos.FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound((int)request.ProfissionalId, profissional);

        var entity = new ConsumoAlimentar
        {
            Profissional = profissional,
            Aluno = aluno,
            Respostas = request.Respostas,
            StatusConsumoAlimentar = request.StatusConsumoAlimentar,
            Encaminhamento = GetEncaminhamento(request.Respostas)
        };

        _context.ConsumoAlimentares.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    private Encaminhamento? GetEncaminhamento(string strRespostas)
    {

        decimal quadrante1;

        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.ConsumoAlimentar);

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.ConsumoAlimentar).ToList();

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

        var encaminhamentoConsumoAlimentar = encaminhamentos.First(x => x.Parametro == parametro);

        return encaminhamentoConsumoAlimentar;

    }
}
