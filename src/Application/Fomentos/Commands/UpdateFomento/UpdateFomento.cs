using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomentos.Commands.UpdateFomento;

public record UpdateFomentoCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int MunicipioId { get; init; }
    public required int LocalidadeId { get; init; }
    public required string Nome { get; init; }
    public required string Codigo { get; init; }
    public bool Status { get; init; }
    public required string DtIni { get; init; }
    public required string DtFim { get; init; }
    public required string LinhaAcoes { get; init; }
}

public class UpdateFomentoCommandHandler : IRequestHandler<UpdateFomentoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateFomentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateFomentoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Fomentos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

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

        entity.Nome = request.Nome;
        entity.Codigo = request.Codigo;
        entity.Localidade = localidade;
        entity.Municipio = municipio;
        entity.Status = request.Status;
        entity.DtIni = DateTime.ParseExact(request.DtIni, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
        entity.DtFim = DateTime.ParseExact(request.DtFim, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
        //entity.LinhasAcoes = listLinhasAcoes;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
