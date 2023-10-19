using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.UpdateQualidadeVida;

public record UpdateQualidadeVidaCommand : IRequest<int>
{
}

public class UpdateQualidadeVidaCommandValidator : AbstractValidator<UpdateQualidadeVidaCommand>
{
    public UpdateQualidadeVidaCommandValidator()
    {
    }
}

public class UpdateQualidadeVidaCommandHandler : IRequestHandler<UpdateQualidadeVidaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateQualidadeVidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateQualidadeVidaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
