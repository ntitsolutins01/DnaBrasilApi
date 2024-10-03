using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoVocacional;

public record UpdateEncaminhamentoVocacionalCommand : IRequest<bool>
{
    public int? AlunoId { get; init; }
}

public class UpdateEncaminhamentoVocacionalCommandHandler : IRequestHandler<UpdateEncaminhamentoVocacionalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEncaminhamentoVocacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEncaminhamentoVocacionalCommand request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos.Where(x => x.Id == 37315)//37315 - Feminino 38438
            .AsNoTracking();

        Dictionary<string, decimal> dict = new()
        {
            { "TecnologiasAplicadas", 0 },
            { "CienciasExatasNaturais", 0 },
            { "Artistico", 0 },
            { "CienciasHumanas", 0 },
            { "Empreendedorismo", 0 },
            { "CienciasContabeisAdministrativas", 0 }
        };

        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == 6);

        var verificaAlunos = alunos.Select(x => x.Id);

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.Vocacional).Where(x => x.Vocacional != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        decimal respostas1;
        decimal respostas2;
        decimal respostas3;
        decimal respostas4;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == 6).ToList();

        foreach (var aluno in laudos)
        {
            List<int> listRespostas = aluno.Vocacional!.Respostas.Split(',').Select(item => int.Parse(item)).ToList();

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

                if (result == null || !dict.ContainsKey(result.Aviso.Split('.')[0]))
                {
                    continue;
                }

                var value = dict[result.Aviso.Split('.')[0]];

                value += 1;

                dict[result.Aviso.Split('.')[0]] = value;

                if (aluno.Aluno.Sexo == "M")
                {
                    var parametro = result.Aviso.Split('.').First();

                    var encaminhamentoVocacional = encaminhamentos.First(x => x.Parametro == parametro);

                    var entity = await _context.Vocacionais
                        .FindAsync([aluno.Vocacional.Id], cancellationToken);

                    Guard.Against.NotFound(aluno.Vocacional.Id, entity);

                    entity.Encaminhamento = encaminhamentoVocacional;

                    var final = await _context.SaveChangesAsync(cancellationToken);

                    return final == 1;
                }
                else
                {
                    var parametro = result.Aviso.Split('.').First();

                    var encaminhamentoVocacional = encaminhamentos.First(x => x.Parametro == parametro);

                    var entity = await _context.Vocacionais
                        .FindAsync([aluno.Vocacional.Id], cancellationToken);

                    Guard.Against.NotFound(aluno.Vocacional.Id, entity);

                    entity.Encaminhamento = encaminhamentoVocacional;

                    var final = await _context.SaveChangesAsync(cancellationToken);

                    return final == 1;
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

                if (result == null || !dict.ContainsKey(result.Aviso.Split('.')[0]))
                {
                    continue;
                }


                var value = dict[result.Aviso.Split('.')[0]];

                value += 1;

                dict[result.Aviso.Split('.')[0]] = value;

                if (aluno.Aluno.Sexo == "M")
                {
                    var parametro = result.Aviso.Split('.').First();

                    var encaminhamentoVocacional = encaminhamentos.First(x => x.Parametro == parametro);

                    var entity = await _context.Vocacionais
                        .FindAsync([aluno.Vocacional.Id], cancellationToken);

                    Guard.Against.NotFound(aluno.Vocacional.Id, entity);

                    entity.Encaminhamento = encaminhamentoVocacional;

                    var final = await _context.SaveChangesAsync(cancellationToken);

                    return final == 1;
                }
                else
                {
                    var parametro = result.Aviso.Split('.').First();

                    var encaminhamentoVocacional = encaminhamentos.First(x => x.Parametro == parametro);

                    var entity = await _context.Vocacionais
                        .FindAsync([aluno.Vocacional.Id], cancellationToken);

                    Guard.Against.NotFound(aluno.Vocacional.Id, entity);

                    entity.Encaminhamento = encaminhamentoVocacional;

                    var final = await _context.SaveChangesAsync(cancellationToken);

                    return final == 1;
                }
            }
        }

        return false;
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
