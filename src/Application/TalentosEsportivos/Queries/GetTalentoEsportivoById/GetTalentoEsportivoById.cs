using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TalentosEsportivos.Queries.GetTalentoEsportivoById;

public record GetTalentoEsportivoByIdQuery(int Id) : IRequest<TalentoEsportivoDto>;


public class GetTalentoEsportivoByIdQueryHandler : IRequestHandler<GetTalentoEsportivoByIdQuery, TalentoEsportivoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTalentoEsportivoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TalentoEsportivoDto> Handle(GetTalentoEsportivoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TalentosEsportivos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<TalentoEsportivoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
