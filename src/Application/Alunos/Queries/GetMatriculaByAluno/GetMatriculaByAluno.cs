using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Queries.GetMatriculaByAluno;

public record GetMatriculaByAlunoQuery : IRequest<MatriculaDto>
{
}

public class GetMatriculaByAlunoQueryValidator : AbstractValidator<GetMatriculaByAlunoQuery>
{
    public GetMatriculaByAlunoQueryValidator()
    {
    }
}

public class GetMatriculaByAlunoQueryHandler : IRequestHandler<GetMatriculaByAlunoQuery, MatriculaDto>
{
    private readonly IApplicationDbContext _context;

    public GetMatriculaByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<MatriculaDto> Handle(GetMatriculaByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
