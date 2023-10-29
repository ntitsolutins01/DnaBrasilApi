using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.SaudeByAluno;

public record GetSaudeByAlunoQuery : IRequest<SaudeDto>
{
}

public class GetSaudeByAlunoQueryValidator : AbstractValidator<GetSaudeByAlunoQuery>
{
    public GetSaudeByAlunoQueryValidator()
    {
    }
}

public class GetSaudeByAlunoQueryHandler : IRequestHandler<GetSaudeByAlunoQuery, SaudeDto>
{
    private readonly IApplicationDbContext _context;

    public GetSaudeByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<SaudeDto> Handle(GetSaudeByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
