using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.VocacionalByAluno;

public record VocacionalByAlunoQuery : IRequest<VocacionalDto>
{
}

public class VocacionalByAlunoQueryValidator : AbstractValidator<VocacionalByAlunoQuery>
{
    public VocacionalByAlunoQueryValidator()
    {
    }
}

public class VocacionalByAlunoQueryHandler : IRequestHandler<VocacionalByAlunoQuery, VocacionalDto>
{
    private readonly IApplicationDbContext _context;

    public VocacionalByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<VocacionalDto> Handle(VocacionalByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
