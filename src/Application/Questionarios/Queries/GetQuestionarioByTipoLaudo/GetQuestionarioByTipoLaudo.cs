using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Queries.GetQuestionarioByTipoLaudo;

public record GetQuestionarioByTipoLaudoCommand : IRequest<int>
{
}

public class GetQuestionarioByTipoLaudoCommandValidator : AbstractValidator<GetQuestionarioByTipoLaudoCommand>
{
    public GetQuestionarioByTipoLaudoCommandValidator()
    {
    }
}

public class GetQuestionarioByTipoLaudoCommandHandler : IRequestHandler<GetQuestionarioByTipoLaudoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionarioByTipoLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public  Task<int> Handle(GetQuestionarioByTipoLaudoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
