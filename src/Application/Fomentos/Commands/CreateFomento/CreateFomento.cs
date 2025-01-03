using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.Fomentos.Commands.CreateFomento;
public record CreateFomentoCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required int MunicipioId { get; init; }
    public required int LocalidadeId { get; init; }
    public required string Codigo { get; init; }
    public required string DtIni { get; init; }
    public required string DtFim { get; init; }
    public required string LinhaAcoes { get; init; }
}

public class CreateFomentoCommandHandler : IRequestHandler<CreateFomentoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFomentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFomentoCommand request, CancellationToken cancellationToken)
    {
        var municipio = await _context.Municipios
            .FindAsync([request.MunicipioId], cancellationToken);

        Guard.Against.NotFound(request.MunicipioId, municipio);

        var localidade = await _context.Localidades
            .FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        var listLinhasAcoes = new List<LinhaAcao>();

        if (!string.IsNullOrEmpty(request.LinhaAcoes))
        {
            int[] ia = request.LinhaAcoes.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            foreach (var item in ia)
            {
                var linhaAcao = await _context.LinhasAcoes
                    .FindAsync([item], cancellationToken);

                if (linhaAcao != null)
                {
                    listLinhasAcoes.Add(linhaAcao);
                }
            }
        }

        var entity = new Fomentu
        {
            Codigo = request.Codigo,
            Nome = request.Nome,
            Municipio = municipio,
            Localidade = localidade!,
            DtIni = DateTime.ParseExact(request.DtIni, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            DtFim = DateTime.ParseExact(request.DtFim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            //LinhasAcoes = listLinhasAcoes
        };

        _context.Fomentos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
