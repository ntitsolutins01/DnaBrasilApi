using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Certificados.Queries.GetCertificadosByAlunoId;

public record GetCertificadosByAlunoIdQuery : IRequest<List<CertificadoDto>>
{
    public required int AlunoId { get; init; }
}

public class GetCertificadosByAlunoIdQueryHandler : IRequestHandler<GetCertificadosByAlunoIdQuery, List<CertificadoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCertificadosByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CertificadoDto>> Handle(GetCertificadosByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosCertificados
            .Where(ac => ac.Aluno.Id == request.AlunoId)
            .Include(ac => ac.Certificado)
            .AsNoTracking()
            .Select(ac => ac.Certificado)
            .ProjectTo<CertificadoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result ?? throw new ArgumentNullException(nameof(result));
    }
}
