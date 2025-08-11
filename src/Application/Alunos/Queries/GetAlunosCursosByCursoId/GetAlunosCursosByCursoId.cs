using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunosCursosByCursoId;
//[Authorize]
public record GetAlunosCursosByCursoIdQuery : IRequest<List<AlunoCursoDto>>
{
    public required int CursoId { get; init; }
    public required int IdTipoCurso { get; init; }
}

public class GetAlunosCursosByCursoIdQueryHandler : IRequestHandler<GetAlunosCursosByCursoIdQuery, List<AlunoCursoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosCursosByCursoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoCursoDto>> Handle(GetAlunosCursosByCursoIdQuery request, CancellationToken cancellationToken)
    {
        List<AlunoCursoDto> result = [];

        if (request.IdTipoCurso != 0)
        {
            result = await _context.AlunoCursosCertificados
                .Where((x => x.Curso!.TipoCurso.Id == request.IdTipoCurso))
                .AsNoTracking()
                .ProjectTo<AlunoCursoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        if (request.CursoId != 0)
        {
            result = await _context.AlunoCursosCertificados
                .Where((x => x.CursoId == request.CursoId))
                .AsNoTracking()
                .ProjectTo<AlunoCursoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        return result;
    }
}
