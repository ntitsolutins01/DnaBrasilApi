using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.AlunosCertificados.Queries.GetAlunoCertificadoById;

public record GetAlunoCertificadoByIdQuery : IRequest<AlunoCertificadoDto>
{
    public required int Id { get; init; }
}

public class GetAlunoCertificadoByIdQueryHandler : IRequestHandler<GetAlunoCertificadoByIdQuery, AlunoCertificadoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunoCertificadoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AlunoCertificadoDto> Handle(GetAlunoCertificadoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosCertificados
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<AlunoCertificadoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
