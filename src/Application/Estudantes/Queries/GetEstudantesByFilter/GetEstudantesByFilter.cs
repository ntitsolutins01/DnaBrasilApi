using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Estudantes.Queries.GetEstudantesByFilter;

public record GetEstudantesByFilterQuery : IRequest<List<EstudanteDto>>
{
    public SearchEstudantesDto? Search { get; init; }
}

public class GetEstudantesByFilterQueryHandler : IRequestHandler<GetEstudantesByFilterQuery, List<EstudanteDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstudantesByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EstudanteDto>> Handle(GetEstudantesByFilterQuery request, CancellationToken cancellationToken)
    {
        var Estudantes = _context.Alunos
            .AsNoTracking();
            
        var result = FilterEstudantes(Estudantes, request.Search!)
            .ProjectTo<EstudanteDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken); ;

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Aluno> FilterEstudantes(IQueryable<Aluno> Estudantes, SearchEstudantesDto search)
    {
        //if (!string.IsNullOrWhiteSpace(search.ParceiroId))
        //    Estudantes = Estudantes.Where(u => u.ParceiroId = search.ParceiroId);

        //TODO: DRK implementar resto dos filtros

        return Estudantes;
    }
}
