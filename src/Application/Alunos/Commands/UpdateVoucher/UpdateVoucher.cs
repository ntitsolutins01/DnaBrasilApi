using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.UpdateVoucher;

public record UpdateVoucherCommand : IRequest<int>
{
}

public class UpdateVoucherCommandValidator : AbstractValidator<UpdateVoucherCommand>
{
    public UpdateVoucherCommandValidator()
    {
    }
}

public class UpdateVoucherCommandHandler : IRequestHandler<UpdateVoucherCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateVoucherCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateVoucherCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
