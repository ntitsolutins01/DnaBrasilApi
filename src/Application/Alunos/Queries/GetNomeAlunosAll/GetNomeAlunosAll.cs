using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosAll;
//[Authorize]
public record GetNomeAlunosAllQuery : IRequest<List<SelectListDto>>;

public class GetNomeAlunosAllQueryHandler : IRequestHandler<GetNomeAlunosAllQuery, List<SelectListDto>>
{
    private readonly IApplicationDbContext _context;

    public GetNomeAlunosAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SelectListDto>> Handle(GetNomeAlunosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
                .AsNoTracking()
                .Select(s => new SelectListDto { Id = s.Id, Nome = s.Id + " - " + s.Nome.ToUpper() })
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken);

        return result;
    }
}

