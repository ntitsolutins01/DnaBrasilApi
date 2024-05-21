using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadoQualidadeVidaAlunos;
//[Authorize]
public record GetTotalizadoQualidadeVidaAlunosQuery : IRequest<TotalizadorQualidadeVidaDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class
    GetTotalizadoQualidadeVidaAlunosQueryHandler : IRequestHandler<GetTotalizadoQualidadeVidaAlunosQuery,
    TotalizadorQualidadeVidaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadoQualidadeVidaAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorQualidadeVidaDto> Handle(GetTotalizadoQualidadeVidaAlunosQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos.Where(x => x.Id == 36847)
            .AsNoTracking();

        var result = FilterAlunosQualidadeVida(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorQualidadeVidaDto FilterAlunosQualidadeVida(IQueryable<Aluno> alunos, DashboardDto search,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            alunos = alunos.Where(u => u.Fomento!.Id == id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            alunos = alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            alunos = alunos.Where(u => u.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            alunos = alunos.Where(u => u.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

            alunos = alunos.Where(u => listAlunos.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            alunos = alunos.Where(u => u.Etnia!.Equals(search.Etnia));
        }

        var verificaAlunos = alunos.Select(x => x.Id);

        Dictionary<string, decimal> dict = new()
        {
            { "BemEstarFisico", 0 },
            { "MalEstarFisico", 0 },
            { "AutoEstima", 0 },
            { "BaixaAutoEstima", 0 },
            { "FuncionamentoHarmonico", 0 },
            { "Conflitos", 0 },
            { "ContextosFavorecedores", 0 },
            { "ContextosNaoFavorecedores", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorQualidadeMasculino = new()
        {
            { "BemEstarFisico", 0 },
            { "MalEstarFisico", 0 },
            { "AutoEstima", 0 },
            { "BaixaAutoEstima", 0 },
            { "FuncionamentoHarmonico", 0 },
            { "Conflitos", 0 },
            { "ContextosFavorecedores", 0 },
            { "ContextosNaoFavorecedores", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorQualidadeFeminino = new()
        {
            { "BemEstarFisico", 0 },
            { "MalEstarFisico", 0 },
            { "AutoEstima", 0 },
            { "BaixaAutoEstima", 0 },
            { "FuncionamentoHarmonico", 0 },
            { "Conflitos", 0 },
            { "ContextosFavorecedores", 0 },
            { "ContextosNaoFavorecedores", 0 }
        };
        
        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.QualidadeDeVida)
            .Include(a => a.Aluno)
            .AsNoTracking();

        foreach (var aluno in laudos)
        {
            if (aluno.QualidadeDeVida == null)
            {
                continue;
            }

            List<int> listRespostas = aluno.QualidadeDeVida.Resposta.Split(',').Select(item => int.Parse(item)).ToList();

            var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i=>i.Questionario);
            
            var quadrante1 = respostas.Where(x => x.Questionario.Quadrante == 1).Sum(s => s.ValorPesoResposta);
            var quadrante2 = respostas.Where(x => x.Questionario.Quadrante == 2).Sum(s => s.ValorPesoResposta);
            var quadrante3 = respostas.Where(x => x.Questionario.Quadrante == 3).Sum(s => s.ValorPesoResposta);
            var quadrante4 = respostas.Where(x => x.Questionario.Quadrante == 4).Sum(s => s.ValorPesoResposta);

            var list = new List<decimal> { quadrante1, quadrante2, quadrante3, quadrante4 };

            var metricas = _context.TextosLaudos
                .Where(x => x.TipoLaudo.Id == 7).ToList();

            foreach (decimal quadrante in list)
            {
                var result = metricas.Find(
                    delegate (TextoLaudo item)
                    {
                        return quadrante >= item.PontoInicial && quadrante <= item.PontoFinal;
                    }
                );

                if (result == null || !dict.ContainsKey(result.Aviso.Split('.')[0]))
                {
                    continue;
                }

                var value = dict[result.Aviso.Split('.')[0]];

                value += 1;

                dict[result.Aviso.Split('.')[0]] = value;

                if (aluno.Aluno.Sexo == "M")
                {
                    var valor = dictTotalizadorQualidadeMasculino[result.Aviso.Split('.')[0]];

                    valor += 1;

                    dictTotalizadorQualidadeMasculino[result.Aviso.Split('.')[0]] = valor;
                }
                else
                {
                    var valor = dictTotalizadorQualidadeFeminino[result.Aviso.Split('.')[0]];

                    valor += 1;

                    dictTotalizadorQualidadeFeminino[result.Aviso.Split('.')[0]] = valor;
                }
            }
        }

        return new TotalizadorQualidadeVidaDto();
    }

}
