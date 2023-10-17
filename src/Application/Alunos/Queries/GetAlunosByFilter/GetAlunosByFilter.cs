using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Queries.GetAlunosByFilter;

public record GetAlunosByFilterQuery : IRequest<AlunoDto>
{
}

public class GetAlunosByFilterQueryValidator : AbstractValidator<GetAlunosByFilterQuery>
{
    public GetAlunosByFilterQueryValidator()
    {
    }
}

public class GetAlunosByFilterQueryHandler : IRequestHandler<GetAlunosByFilterQuery, AlunoDto>
{
    private readonly IApplicationDbContext _context;

    public GetAlunosByFilterQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AlunoDto> Handle(GetAlunosByFilterQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
