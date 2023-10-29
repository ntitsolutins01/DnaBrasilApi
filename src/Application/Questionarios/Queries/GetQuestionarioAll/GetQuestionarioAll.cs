using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Queries.GetQuestionarioAll;

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

    public Task<int> Handle(GetQuestionarioAllCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
