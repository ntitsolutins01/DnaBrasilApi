using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Commands.GetQuestionarioAll;

public record GetQuestionarioAllCommand : IRequest<int>
{
}

public class GetQuestionarioAllCommandValidator : AbstractValidator<GetQuestionarioAllCommand>
{
    public GetQuestionarioAllCommandValidator()
    {
    }
}

public class GetQuestionarioAllCommandHandler : IRequestHandler<GetQuestionarioAllCommand, int>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionarioAllCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(GetQuestionarioAllCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
