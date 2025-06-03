using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Commands.DeleteAtividadeAluno;

public record DeleteAtividadeAlunoCommand : IRequest<bool>
{
    public required int AtividadeId { get; init; }
}

public class DeleteAtividadeAlunoCommandHandler : IRequestHandler<DeleteAtividadeAlunoCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteAtividadeAlunoCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteAtividadeAlunoCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.AtividadeAlunos
            .Where(x => x.AtividadeId == request.AtividadeId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _context.AtividadeAlunos.RemoveRange(list);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
