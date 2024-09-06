using System.Threading;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;

public record CreateVocacionalCommand : IRequest<int>
{
    public required int ProfissionalId { get; init; }
    public required int AlunoId { get; init; }
    public required string Respostas { get; init; }
    public required string StatusVocacional { get; init; }
}

public class CreateVocacionalCommandHandler : IRequestHandler<CreateVocacionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateVocacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateVocacionalCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos.FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound((int)request.ProfissionalId, profissional);

        var entity = new Vocacional
        {
            Profissional = profissional,
            Aluno = aluno,
            Respostas = request.Respostas,
            StatusVocacional = request.StatusVocacional,
            Encaminhamento = GetEncaminhamento(request.Respostas, aluno)
        };

        _context.Vocacionais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    private Encaminhamento GetEncaminhamento(string strRespostas, Aluno aluno)
    {
        Dictionary<string, decimal> dict = new()
        {
            { "TecnologiasAplicadas", 0 },
            { "CienciasExatasNaturais", 0 },
            { "Artistico", 0 },
            { "CienciasHumanas", 0 },
            { "Empreendedorismo", 0 },
            { "CienciasContabeisAdministrativas", 0 }
        };

        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.Vocacional);

        decimal respostas1;
        decimal respostas2;
        decimal respostas3;
        decimal respostas4;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == 6).ToList();

        List<int> listRespostas = strRespostas.Split(',').Select(item => int.Parse(item)).ToList();

        var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

        respostas1 = respostas.Count(x => x.ValorPesoResposta == 1);
        respostas2 = respostas.Count(x => x.ValorPesoResposta == 2);
        respostas3 = respostas.Count(x => x.ValorPesoResposta == 3);
        respostas4 = respostas.Count(x => x.ValorPesoResposta == 4);

        Dictionary<int, decimal> dicRespostas = new()
        {
            { 1, respostas1 },
            { 2, respostas2 },
            { 3, respostas3 },
            { 4, respostas4 }
        };

        var sortedDict = from entry in dicRespostas orderby entry.Value descending select entry;

        if (sortedDict.First().Key != 1 && sortedDict.First().Key != 4)
        {
            var result = metricas.Find(
                delegate (TextoLaudo item)

                {
                    return sortedDict.First().Key == 2 ? item.PontoFinal == 2 : item.PontoFinal == 3;
                }
            );

            //if (result == null || !dict.ContainsKey(result.Aviso.Split('.')[0]))
            //{
            //    return;
            //}

            var value = dict[result!.Aviso.Split('.')[0]];

            value += 1;

            dict[result!.Aviso.Split('.')[0]] = value;

            if (aluno.Sexo == "M")
            {
                var parametro = result.Aviso.Split('.').First();

                var encaminhamentoVocacional = encaminhamentos.First(x => x.Parametro == parametro);

                return encaminhamentoVocacional;
            }
            else
            {
                var parametro = result.Aviso.Split('.').First();

                var encaminhamentoVocacional = encaminhamentos.First(x => x.Parametro == parametro);

                return encaminhamentoVocacional;
            }
        }
        else
        {
            var result = metricas.Find(
                delegate (TextoLaudo item)

                {
                    switch (sortedDict.First().Key)
                    {
                        case 1 when IsPrime((int)sortedDict.First().Value):
                            return item.PontoFinal == (decimal?)1.1;
                        case 1 when !IsPrime((int)sortedDict.First().Value):
                            return item.PontoFinal == (decimal?)1.2;
                        case 4 when IsPrime((int)sortedDict.First().Value):
                            return item.PontoFinal == (decimal?)4.1;
                        case 4 when !IsPrime((int)sortedDict.First().Value):
                            return item.PontoFinal == (decimal?)4.2;
                    }

                    return false;
                }
            );

            //if (result == null || !dict.ContainsKey(result.Aviso.Split('.')[0]))
            //{
            //    continue;
            //}


            var value = dict[result!.Aviso.Split('.')[0]];

            value += 1;

            dict[result.Aviso.Split('.')[0]] = value;

            if (aluno.Sexo == "M")
            {
                var parametro = result.Aviso.Split('.').First();

                var encaminhamentoVocacional = encaminhamentos.First(x => x.Parametro == parametro);

                return encaminhamentoVocacional;
            }
            else
            {
                var parametro = result.Aviso.Split('.').First();

                var encaminhamentoVocacional = encaminhamentos.First(x => x.Parametro == parametro);

                return encaminhamentoVocacional;
            }
        }
    }

    private Boolean IsPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;

        var limit = Math.Ceiling(Math.Sqrt(number)); //hoisting the loop limit

        for (int i = 2; i <= limit; ++i)
            if (number % i == 0)
                return false;
        return true;

    }
}
