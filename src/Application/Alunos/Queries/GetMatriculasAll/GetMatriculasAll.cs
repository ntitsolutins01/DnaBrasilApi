using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetMatriculasAll;
//[Authorize]
public record GetMatriculasAllQuery : IRequest<List<MatriculaDto>>;

public class GetMatriculasAllQueryHandler : IRequestHandler<GetMatriculasAllQuery, List<MatriculaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMatriculasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MatriculaDto>> Handle(GetMatriculasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.MatriculasOld
            .AsNoTracking()
            .ProjectTo<MatriculaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
