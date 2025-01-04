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
    public string? LinhasAcoesIds { get; init; }
    public string? LocalidadesIds { get; init; }
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

        var entity = new Fomentu
        {
            Codigo = request.Codigo,
            Nome = request.Nome,
            Municipio = municipio,
            Localidade = localidade!,
            DtIni = DateTime.ParseExact(request.DtIni, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            DtFim = DateTime.ParseExact(request.DtFim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
        };

        _context.Fomentos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        var listFomentoLocalidades = new List<FomentoLocalidade>();

        if (!string.IsNullOrEmpty(request.LocalidadesIds))
        {
            int[] arrLocsIds = request.LocalidadesIds.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            listFomentoLocalidades.AddRange(arrLocsIds.Select(item => new FomentoLocalidade { LocalidadeId = item, FomentoId = entity.Id }));
        }

        entity.FomentoLocalidades = listFomentoLocalidades;

        var listFomentoLinhasAcoes = new List<FomentoLinhaAcao>();

        if (!string.IsNullOrEmpty(request.LinhasAcoesIds))
        {
            int[] arrLinAcIds = request.LinhasAcoesIds.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            listFomentoLinhasAcoes.AddRange(arrLinAcIds.Select(item => new FomentoLinhaAcao { LinhaAcaoId = item, FomentoId = entity.Id }));
        }

        entity.FomentoLinhasAcoes = listFomentoLinhasAcoes;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
