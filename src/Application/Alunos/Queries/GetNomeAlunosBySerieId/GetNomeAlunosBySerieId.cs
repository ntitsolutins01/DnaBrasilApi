using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosBySerieId;
//[Authorize]
public record GetNomeAlunosBySerieIdQuery : IRequest<List<SelectListDto>>
{
    public required int SerieId { get; init; }
}

public class GetNomeAlunosBySerieIdQueryHandler : IRequestHandler<GetNomeAlunosBySerieIdQuery, List<SelectListDto>>
{
    private readonly IApplicationDbContext _context;

    public GetNomeAlunosBySerieIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SelectListDto>> Handle(GetNomeAlunosBySerieIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .Where(x => x.Serie!.Id == request.SerieId && x.Convidado == false)                
            .OrderBy(t => t.Nome)
            .Select(s => new SelectListDto { Id = s.Id, Nome = s.Id + " - " + s.Nome.ToUpper() })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return result;
    }
}

