using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoDisciplina;

public record DeleteAlunoDisciplinaCommand : IRequest<bool>
{
    public required int AlunoId { get; init; }
}

public class DeleteAlunoDisciplinaCommandHandler : IRequestHandler<DeleteAlunoDisciplinaCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteAlunoDisciplinaCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteAlunoDisciplinaCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.AlunosDisciplinas
            .Where(x => x.AlunoId == request.AlunoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _context.AlunosDisciplinas.RemoveRange(list);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
