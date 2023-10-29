using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.SaudeBucalByAluno;

public record GetSaudeBucalByAlunoQuery : IRequest<SaudeBucalDto>
{
}

public class GetSaudeBucalByAlunoQueryValidator : AbstractValidator<GetSaudeBucalByAlunoQuery>
{
    public GetSaudeBucalByAlunoQueryValidator()
    {
    }
}

public class GetSaudeBucalByAlunoQueryHandler : IRequestHandler<GetSaudeBucalByAlunoQuery, SaudeBucalDto>
{
    private readonly IApplicationDbContext _context;

    public GetSaudeBucalByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<SaudeBucalDto> Handle(GetSaudeBucalByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
