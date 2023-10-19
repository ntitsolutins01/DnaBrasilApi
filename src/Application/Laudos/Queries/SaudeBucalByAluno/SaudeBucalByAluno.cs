using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.SaudeBucalByAluno;

public record SaudeBucalByAlunoQuery : IRequest<SaudeBucalDto>
{
}

public class SaudeBucalByAlunoQueryValidator : AbstractValidator<SaudeBucalByAlunoQuery>
{
    public SaudeBucalByAlunoQueryValidator()
    {
    }
}

public class SaudeBucalByAlunoQueryHandler : IRequestHandler<SaudeBucalByAlunoQuery, SaudeBucalDto>
{
    private readonly IApplicationDbContext _context;

    public SaudeBucalByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SaudeBucalDto> Handle(SaudeBucalByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
