using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Profissionais.Queries.ProfissionalByAluno;

public record ProfissionalByAlunoQuery : IRequest<ProfissionalDto>
{
}

public class ProfissionalByAlunoQueryValidator : AbstractValidator<ProfissionalByAlunoQuery>
{
    public ProfissionalByAlunoQueryValidator()
    {
    }
}

public class ProfissionalByAlunoQueryHandler : IRequestHandler<ProfissionalByAlunoQuery, ProfissionalDto>
{
    private readonly IApplicationDbContext _context;

    public ProfissionalByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<ProfissionalDto> Handle(ProfissionalByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
