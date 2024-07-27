using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Localidades.Queries.GetLocalidadesByFomento;

public record GetLocalidadesByFomentoQuery : IRequest<List<LocalidadeDto>>
{
    public required int Id { get; init; }
}

public class GetLocalidadesByFomentoQueryHandler : IRequestHandler<GetLocalidadesByFomentoQuery, List<LocalidadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLocalidadesByFomentoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LocalidadeDto>> Handle(GetLocalidadesByFomentoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _context.Fomentos
                .Where(x => x.Localidade.Id == request.Id)
                .Select(s=>s.Localidade)
                .AsNoTracking()
                .ProjectTo<LocalidadeDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Nome)
                .ToListAsync(cancellationToken);

            return result;
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
            throw;
        }
    }
}
