using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Certificados.Queries.GetCertificadosAll;
//[Authorize]
public record GetCertificadosAllQuery : IRequest<List<CertificadoDto>>;

public class GetCertificadosAllQueryHandler : IRequestHandler<GetCertificadosAllQuery, List<CertificadoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCertificadosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CertificadoDto>> Handle(GetCertificadosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Certificados
            .AsNoTracking()
            .ProjectTo<CertificadoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
