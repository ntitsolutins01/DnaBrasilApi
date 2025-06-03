using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosByProfissionalId;
//[Authorize]
public record GetNomeAlunosByProfissionalIdQuery : IRequest<List<SelectListDto>>
{
    public required int ProfissionalId { get; init; }
}

public class GetNomeAlunosByProfissionalIdQueryHandler : IRequestHandler<GetNomeAlunosByProfissionalIdQuery, List<SelectListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNomeAlunosByProfissionalIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SelectListDto>> Handle(GetNomeAlunosByProfissionalIdQuery request, CancellationToken cancellationToken)
    {
        var result = new List<SelectListDto>();

        result = await _context.Alunos
            .Where(x => x.Profissional!.Id == request.ProfissionalId)
            .Select(s => new SelectListDto { Id = s.Id, Nome = s.Id + " - " + s.Nome.ToUpper() })
            .AsNoTracking()
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result;
    }
}

