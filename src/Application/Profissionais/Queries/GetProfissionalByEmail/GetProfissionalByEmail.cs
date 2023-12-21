using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalByEmail;
//[Authorize]
public record GetProfissionalByEmailQuery : IRequest<ProfissionalDto>
{
    public required string Email { get; init; }
}

public class GetProfissionalByEmailQueryHandler : IRequestHandler<GetProfissionalByEmailQuery, ProfissionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProfissionalByEmailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProfissionalDto> Handle(GetProfissionalByEmailQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Profissionais
            .Where(x => x.Email == request.Email)
            .AsNoTracking()
            .ProjectTo<ProfissionalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return result!;
    }
}

