using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoAula;

public record DeleteAlunoAulaCommand : IRequest<bool>
{
    public required int AlunoId { get; init; }
}

public class DeleteAlunoAulaCommandHandler : IRequestHandler<DeleteAlunoAulaCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteAlunoAulaCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteAlunoAulaCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.AlunosAulas
            .Where(x => x.AlunoId == request.AlunoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _context.AlunosAulas.RemoveRange(list);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
