using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.CreateVoucher;

public record CreateVoucherCommand : IRequest<int>
{
}

public class CreateVoucherCommandValidator : AbstractValidator<CreateVoucherCommand>
{
    public CreateVoucherCommandValidator()
    {
    }
}

public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateVoucherCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
