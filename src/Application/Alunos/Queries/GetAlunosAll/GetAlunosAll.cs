using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Queries.GetAlunosAll;

public record GetAlunosAllQuery : IRequest<AlunoDto>
{
}

public class GetAlunosAllQueryValidator : AbstractValidator<GetAlunosAllQuery>
{
    public GetAlunosAllQueryValidator()
    {
    }
}

public class GetAlunosAllQueryHandler : IRequestHandler<GetAlunosAllQuery, AlunoDto>
{
    private readonly IApplicationDbContext _context;

    public GetAlunosAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<AlunoDto> Handle(GetAlunosAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
