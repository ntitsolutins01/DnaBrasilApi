using DnaBrasilApi.Application.Common.Interfaces;


namespace DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalByCpfCnpj;
//[Authorize]
public record GetProfissionalByCpfCnpjQuery : IRequest<ProfissionalDto>
{
    public required string CpfCnpj { get; init; }
}

public class GetProfissionalByCpfCnpjQueryHandler : IRequestHandler<GetProfissionalByCpfCnpjQuery, ProfissionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProfissionalByCpfCnpjQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProfissionalDto> Handle(GetProfissionalByCpfCnpjQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Profissionais
            .Where(x => x.CpfCnpj == request.CpfCnpj)
            .AsNoTracking()
            .ProjectTo<ProfissionalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return result!;
    }
}

