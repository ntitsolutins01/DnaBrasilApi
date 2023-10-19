using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Deficiencias.Queries.GetDeficienciasAll;

namespace DnaBrasil.Application.Alunos.Queries.GetDeficienciasByAluno;

public record GetDeficienciasByAlunoQuery : IRequest<DeficienciaDto>
{
}

public class GetDeficienciasByAlunoQueryValidator : AbstractValidator<GetDeficienciasByAlunoQuery>
{
    public GetDeficienciasByAlunoQueryValidator()
    {
    }
}

public class GetDeficienciasByAlunoQueryHandler : IRequestHandler<GetDeficienciasByAlunoQuery, DeficienciaDto>
{
    private readonly IApplicationDbContext _context;

    public GetDeficienciasByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<DeficienciaDto> Handle(GetDeficienciasByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
