using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Fomentos.Queries;
using DnaBrasilApi.Application.Localidades.Queries;

namespace DnaBrasilApi.Application.Municipios.Queries.GetMunicipiosByFomentoId;

public record GetMunicipiosByFomentoIdQuery : IRequest<List<MunicipioDto>>
{
    public required int Id { get; init; }
}

public class GetMunicipiosByFomentoIdQueryHandler : IRequestHandler<GetMunicipiosByFomentoIdQuery, List<MunicipioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMunicipiosByFomentoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MunicipioDto>> Handle(GetMunicipiosByFomentoIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var fomento = await _context.Fomentos
                .Where(x => x.Id == request.Id)
                .AsNoTracking()
                .ProjectTo<FomentoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            var localidadeIds = fomento!.LocalidadesIds!.Split(',');

            var lisLocalidades = await _context.Localidades
                .Where(x => localidadeIds.Contains(x.Id.ToString()))
                .AsNoTracking()
                .ProjectTo<LocalidadeDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken);

            var municipioIds = lisLocalidades.DistinctBy(d => d.MunicipioId).Select(s => s.MunicipioId).ToList();

            var result = await _context.Municipios
                .Where(x => municipioIds.Contains(x.Id))
                .AsNoTracking()
                .ProjectTo<MunicipioDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
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
