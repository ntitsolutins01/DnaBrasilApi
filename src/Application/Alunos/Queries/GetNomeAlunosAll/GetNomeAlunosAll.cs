using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosAll;
//[Authorize]
public record GetNomeAlunosAllQuery : IRequest<List<SelectListDto>>
{
    public required string LocalidadeId { get; init; }
}

public class GetNomeAlunosAllQueryHandler : IRequestHandler<GetNomeAlunosAllQuery, List<SelectListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNomeAlunosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SelectListDto>> Handle(GetNomeAlunosAllQuery request, CancellationToken cancellationToken)
    {
        var result = new List<SelectListDto>();
        var idLocalidade = Convert.ToInt32(request.LocalidadeId);

        if (string.IsNullOrEmpty(request.LocalidadeId))
        {
            result = await _context.Alunos
                .AsNoTracking()
                .Select(s => new SelectListDto { Id = s.Id, Nome = s.Nome })
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken);
        }
        else
        {
            result = await _context.Alunos
                .Where(x => x.Localidade!.Id == idLocalidade)
                .Select(s => new SelectListDto { Id = s.Id, Nome = s.Nome })
                .AsNoTracking()
                .OrderBy(t => t.Nome)
                .ToListAsync(cancellationToken);
        }

        return result;
    }
}

