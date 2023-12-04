using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Estudantes.Queries.GetEstudantesAll;
//[Authorize]
public record GetEstudantesAllQuery : IRequest<List<EstudanteDto>>;

public class GetEstudantesAllQueryHandler : IRequestHandler<GetEstudantesAllQuery, List<EstudanteDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstudantesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EstudanteDto>> Handle(GetEstudantesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .AsNoTracking()
            .ProjectTo<EstudanteDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result;
    }
}
