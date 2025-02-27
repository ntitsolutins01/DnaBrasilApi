using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.AlunosCertificados.Queries.GetAlunosCertificadosAll;
//[Authorize]
public record GetAlunosCertificadosAllQuery : IRequest<List<AlunoCertificadoDto>>;

public class GetAlunosCertificadosAllQueryHandler : IRequestHandler<GetAlunosCertificadosAllQuery, List<AlunoCertificadoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosCertificadosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoCertificadoDto>> Handle(GetAlunosCertificadosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosCertificados
            .AsNoTracking()
            .ProjectTo<AlunoCertificadoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
