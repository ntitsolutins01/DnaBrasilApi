using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunoCertificadoByAlunoId;
//[Authorize]
public record GetAlunoCertificadosByAlunoIdQuery : IRequest<List<AlunoCertificadoDto>>
{
    public required int AlunoId { get; init; }
}

public class GetAlunoCertificadosByAlunoIdQueryHandler : IRequestHandler<GetAlunoCertificadosByAlunoIdQuery, List<AlunoCertificadoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunoCertificadosByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoCertificadoDto>> Handle(GetAlunoCertificadosByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosCertificados
            .Where((x => x.AlunoId == request.AlunoId))
            .AsNoTracking()
            .ProjectTo<AlunoCertificadoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
