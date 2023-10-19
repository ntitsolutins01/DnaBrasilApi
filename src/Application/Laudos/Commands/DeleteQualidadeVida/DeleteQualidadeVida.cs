using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.DeleteQualidadeVida;

public record DeleteQualidadeVidaCommand : IRequest<int>
{
}

public class DeleteQualidadeVidaCommandValidator : AbstractValidator<DeleteQualidadeVidaCommand>
{
    public DeleteQualidadeVidaCommandValidator()
    {
    }
}

public class DeleteQualidadeVidaCommandHandler : IRequestHandler<DeleteQualidadeVidaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteQualidadeVidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(DeleteQualidadeVidaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
