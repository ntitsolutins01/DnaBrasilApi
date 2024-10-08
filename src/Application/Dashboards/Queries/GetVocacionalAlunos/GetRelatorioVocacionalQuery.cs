﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetVocacionalAlunos;
//[Authorize]
public record GetRelatorioVocacionalQuery : IRequest<VocacionalDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetRelatorioVocacionalQueryHandler : IRequestHandler<GetRelatorioVocacionalQuery, VocacionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRelatorioVocacionalQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<VocacionalDto> Handle(GetRelatorioVocacionalQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos//.Where(x=>x.Id==34493)
            .AsNoTracking();

        var result = FilterAlunos(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private VocacionalDto FilterAlunos(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            alunos = alunos.Where(u => u.Fomento.Id == id);
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
            { "TecnologiasAplicadas", 0 },
            { "CienciasExatasNaturais", 0 },
            { "Artistico", 0 },
            { "CienciasHumanas", 0 },
            { "Empreendedorismo", 0 },
            { "CienciasContabeisAdministrativas", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorVocacionalMasculino = new()
        {

            { "TecnologiasAplicadas", 0 },
            { "CienciasExatasNaturais", 0 },
            { "Artistico", 0 },
            { "CienciasHumanas", 0 },
            { "Empreendedorismo", 0 },
            { "CienciasContabeisAdministrativas", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorVocacionalFeminino = new()
        {

            { "TecnologiasAplicadas", 0 },
            { "CienciasExatasNaturais", 0 },
            { "Artistico", 0 },
            { "CienciasHumanas", 0 },
            { "Empreendedorismo", 0 },
            { "CienciasContabeisAdministrativas", 0 }
        };

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.Vocacional).Where(x => x.Vocacional != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        foreach (var aluno in laudos)
        {
            //List<int> listRespostas = aluno.Vocacional!.Resposta.Split(',').Select(item => int.Parse(item)).ToList();

            //var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

            //respostas1 = respostas.Count(x => x.ValorPesoResposta == 1);
            //respostas2 = respostas.Count(x => x.ValorPesoResposta == 2);
            //respostas3 = respostas.Count(x => x.ValorPesoResposta == 3);
            //respostas4 = respostas.Count(x => x.ValorPesoResposta == 4);

            //Dictionary<int, decimal> dicRespostas = new()
            //{
            //    { 1, respostas1 },
            //    { 2, respostas2 },
            //    { 3, respostas3 },
            //    { 4, respostas4 }
            //};

            //var sortedDict = from entry in dicRespostas orderby entry.Value descending select entry;

            //var duplicados = sortedDict.GroupBy(x => x.Value)
            //    .Select(x => new { Item = x, HasDuplicates = x.Count() > 1 });

            //foreach (var duplicado in duplicados.Where(s=>s.HasDuplicates))
            //{
            //    foreach (var dupli in duplicado.Item)
            //    {
            //        var result = metricas.Find(
            //            delegate (TextoLaudo item)

            //            {
            //                if (dupli.Key == 1 && IsPrime((int)dupli.Value))
            //                {
            //                    return item.PontoFinal == (decimal?)1.1;
            //                }
            //                else if (dupli.Key == 1 && !IsPrime((int)dupli.Value))
            //                {
            //                    return item.PontoFinal == (decimal?)1.2;
            //                }
            //                else if (dupli.Key == 4 && IsPrime((int)dupli.Value))
            //                {
            //                    return item.PontoFinal == (decimal?)4.1;
            //                }
            //                else if (dupli.Key == 4 && !IsPrime((int)dupli.Value))
            //                {
            //                    return item.PontoFinal == (decimal?)4.2;
            //                }
            //                else if (dupli.Key == 2)
            //                {
            //                    return item.PontoFinal == 2;
            //                }
            //                else
            //                {
            //                    return item.PontoFinal == 3;
            //                }
            //            }
            //        );

            //        if (result == null || !dict.ContainsKey(result.Aviso.Split('.')[0]))
            //        {
            //            continue;
            //        }

            //        var value = dict[result.Aviso.Split('.')[0]];

            //        value += 1;

            //        dict[result.Aviso.Split('.')[0]] = value;

            //        if (aluno.Aluno.Sexo == "M")
            //        {
            //            var valor = dictTotalizadorVocacionalMasculino[result.Aviso.Split('.')[0]];

            //            valor += 1;

            //            dictTotalizadorVocacionalMasculino[result.Aviso.Split('.')[0]] = valor;
            //        }
            //        else
            //        {
            //            var valor = dictTotalizadorVocacionalFeminino[result.Aviso.Split('.')[0]];

            //            valor += 1;

            //            dictTotalizadorVocacionalFeminino[result.Aviso.Split('.')[0]] = valor;
            //        }
            //    }
            //}
        }

        //var totalMasc = dictTotalizadorVocacionalMasculino.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percTotalizadorVocacionalMasculino = dictTotalizadorVocacionalMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalMasc).ToString("F")));

        //var totalFem = dictTotalizadorVocacionalFeminino.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percTotalizadorVocacionalFeminino = dictTotalizadorVocacionalFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalFem).ToString("F")));

        //var total = dict.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percVocacional = dict.Where(item => total != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / total).ToString("F")));

        return new VocacionalDto()
        {
            //ValorTotalizadorVocacionalMasculino = dictTotalizadorVocacionalMasculino,
            //ValorTotalizadorVocacionalFeminino = dictTotalizadorVocacionalFeminino,
            //PercTotalizadorVocacionalMasculino = percTotalizadorVocacionalMasculino,
            //PercTotalizadorVocacionalFeminino = percTotalizadorVocacionalFeminino,
            //PercentualVocacional = percVocacional
        };
    }
}

