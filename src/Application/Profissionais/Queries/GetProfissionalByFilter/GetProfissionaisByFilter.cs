using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Profissionais.Queries.GetProfissionalByFilter;

public record GetProfissionaisByFilterQuery : IRequest<List<ProfissionalDto>>
{
    public SearchProfissionaisDto? Search { get; init; }
}

public class GetProfissionaisByFilterQueryHandler : IRequestHandler<GetProfissionaisByFilterQuery, List<ProfissionalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProfissionaisByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProfissionalDto>> Handle(GetProfissionaisByFilterQuery request, CancellationToken cancellationToken)
    {
        var profissionais = _context.Profissionais
            .AsNoTracking();
            
        var result = FilterProfissionais(profissionais, request.Search!)
            .ProjectTo<ProfissionalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken); ;

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Profissional> FilterProfissionais(IQueryable<Profissional> profissionais, SearchProfissionaisDto search)
    {
        if (!string.IsNullOrWhiteSpace(search.Nome))
            profissionais = profissionais.Where(u => u.Nome.Contains(search.Nome));

        return profissionais;
    }
}
