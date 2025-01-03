using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Fomentos.Commands.DeleteFomentoLinhasAcoes;

public record DeleteFomentoLinhasAcoesCommand : IRequest<bool>
{
    public required int FomentoId { get; init; }
}

public class DeleteFomentoLinhasAcoesCommandHandler : IRequestHandler<DeleteFomentoLinhasAcoesCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteFomentoLinhasAcoesCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteFomentoLinhasAcoesCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.FomentoLinhasAcoes
            .Where(x => x.FomentoId == request.FomentoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _context.FomentoLinhasAcoes.RemoveRange(list);

        //foreach (var obj in entity)
        //{
        //    _context.FomentoLinhasAcoes.Remove(obj);
        //}

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
