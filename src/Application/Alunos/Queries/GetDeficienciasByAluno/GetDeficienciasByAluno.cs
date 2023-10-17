using DnaBrasil.Application.Common.Interfaces;

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

    public async Task<DeficienciaDto> Handle(GetDeficienciasByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
