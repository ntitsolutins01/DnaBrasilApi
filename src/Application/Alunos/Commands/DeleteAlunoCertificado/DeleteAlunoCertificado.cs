using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoCertificado;

public record DeleteAlunoCertificadoCommand : IRequest<bool>
{
    public required int AlunoId { get; init; }
}

public class DeleteAlunoCertificadoCommandHandler : IRequestHandler<DeleteAlunoCertificadoCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteAlunoCertificadoCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteAlunoCertificadoCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.AlunosCertificados
            .Where(x => x.AlunoId == request.AlunoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        _context.AlunosCertificados.RemoveRange(list);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
