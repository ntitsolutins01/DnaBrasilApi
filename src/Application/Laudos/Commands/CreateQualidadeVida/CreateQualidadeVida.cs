using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.CreateQualidadeVida;

public record CreateQualidadeVidaCommand : IRequest<int>
{
}

public class CreateQualidadeVidaCommandValidator : AbstractValidator<CreateQualidadeVidaCommand>
{
    public CreateQualidadeVidaCommandValidator()
    {
    }
}

public class CreateQualidadeVidaCommandHandler : IRequestHandler<CreateQualidadeVidaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateQualidadeVidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateQualidadeVidaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
