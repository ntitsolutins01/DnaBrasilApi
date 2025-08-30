using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomentos.Commands.CreateFomentoLocalidades;
public record CreateFomentoLocalidadesCommand : IRequest<int>
{
    public required int FomentoId { get; init; }
    public required string LocalidadesIds { get; init; }
}

public class CreateFomentoLocalidadesCommandHandler : IRequestHandler<CreateFomentoLocalidadesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFomentoLocalidadesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFomentoLocalidadesCommand request, CancellationToken cancellationToken)
    {
        int[] arrLocsIds = request.LocalidadesIds.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

        foreach (int arrLocsId in arrLocsIds)
        {
            var entity = new FomentoLocalidade();

            entity.FomentoId = request.FomentoId;
            entity.LocalidadeId = arrLocsId;

            _context.FomentoLocalidades.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        return request.FomentoId;
    }
}
