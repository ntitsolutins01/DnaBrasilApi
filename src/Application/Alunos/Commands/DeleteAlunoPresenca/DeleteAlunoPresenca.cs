using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoPresenca;

public record DeleteAlunoPresencaCommand : IRequest<bool>
{
    public required int AlunoId { get; init; }
}

public class DeleteAlunoPresencaCommandHandler : IRequestHandler<DeleteAlunoPresencaCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteAlunoPresencaCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteAlunoPresencaCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.AlunosPresencas
            .Where(x => x.AlunoId == request.AlunoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _context.AlunosPresencas.RemoveRange(list);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
