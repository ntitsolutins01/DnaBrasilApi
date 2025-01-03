using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Fomentos.Commands.DeleteFomentoLocalidades;

public record DeleteFomentoLocalidadesCommand : IRequest<bool>
{
    public required int FomentoId { get; init; }
}

public class DeleteFomentoLocalidadesCommandHandler : IRequestHandler<DeleteFomentoLocalidadesCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteFomentoLocalidadesCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteFomentoLocalidadesCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.FomentoLocalidades
            .Where(x => x.FomentoId == request.FomentoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _context.FomentoLocalidades.RemoveRange(list);

        //foreach (var obj in entity)
        //{
        //    _context.FomentoLocalidades.Remove(obj);
        //}

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
