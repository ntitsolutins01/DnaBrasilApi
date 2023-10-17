using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Queries.GetMatriculasAll;

public record GetMatriculasAllQuery : IRequest<MatriculaDto>
{
}

public class GetMatriculasAllQueryValidator : AbstractValidator<GetMatriculasAllQuery>
{
    public GetMatriculasAllQueryValidator()
    {
    }
}

public class GetMatriculasAllQueryHandler : IRequestHandler<GetMatriculasAllQuery, MatriculaDto>
{
    private readonly IApplicationDbContext _context;

    public GetMatriculasAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MatriculaDto> Handle(GetMatriculasAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
