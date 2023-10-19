using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.SaudeByAluno;

public record SaudeByAlunoQuery : IRequest<SaudeDto>
{
}

public class SaudeByAlunoQueryValidator : AbstractValidator<SaudeByAlunoQuery>
{
    public SaudeByAlunoQueryValidator()
    {
    }
}

public class SaudeByAlunoQueryHandler : IRequestHandler<SaudeByAlunoQuery, SaudeDto>
{
    private readonly IApplicationDbContext _context;

    public SaudeByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<SaudeDto> Handle(SaudeByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
