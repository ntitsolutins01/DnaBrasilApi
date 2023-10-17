using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Queries.GetAmbientesByAluno;

public record GetAmbientesByAlunoQuery : IRequest<AmbienteDto>
{
}

public class GetAmbientesByAlunoQueryValidator : AbstractValidator<GetAmbientesByAlunoQuery>
{
    public GetAmbientesByAlunoQueryValidator()
    {
    }
}

public class GetAmbientesByAlunoQueryHandler : IRequestHandler<GetAmbientesByAlunoQuery, AmbienteDto>
{
    private readonly IApplicationDbContext _context;

    public GetAmbientesByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AmbienteDto> Handle(GetAmbientesByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
