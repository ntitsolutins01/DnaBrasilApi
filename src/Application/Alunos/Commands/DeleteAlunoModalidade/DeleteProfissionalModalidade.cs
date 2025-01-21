using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoModalidade;

public record DeleteAlunoModalidadeCommand : IRequest<bool>
{
    public required int AlunoId { get; init; }
}

public class DeleteAlunoModalidadeCommandHandler : IRequestHandler<DeleteAlunoModalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteAlunoModalidadeCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteAlunoModalidadeCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.AlunoModalidades
            .Where(x => x.AlunoId == request.AlunoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _context.AlunoModalidades.RemoveRange(list);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
