using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Certificados.Queries.GetCertificadoById;

public record GetCertificadoByIdQuery : IRequest<CertificadoDto>
{
    public required int Id { get; init; }
}

public class GetCertificadoByIdQueryHandler : IRequestHandler<GetCertificadoByIdQuery, CertificadoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCertificadoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CertificadoDto> Handle(GetCertificadoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Certificados
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<CertificadoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
