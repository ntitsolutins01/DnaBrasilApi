using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.GetTalentoEsportivoByAluno;

public record GetTalentoEsportivoByAlunoQuery : IRequest<TalentoEsportivoDto>
{
}

public class GetTalentoEsportivoByAlunoQueryValidator : AbstractValidator<GetTalentoEsportivoByAlunoQuery>
{
    public GetTalentoEsportivoByAlunoQueryValidator()
    {
    }
}

public class GetTalentoEsportivoByAlunoQueryHandler : IRequestHandler<GetTalentoEsportivoByAlunoQuery, TalentoEsportivoDto>
{
    private readonly IApplicationDbContext _context;

    public GetTalentoEsportivoByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TalentoEsportivoDto> Handle(GetTalentoEsportivoByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
