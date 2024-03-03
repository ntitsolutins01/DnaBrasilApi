using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Localidades.Queries.GetLocalidadesByMunicipio;

public record GetLocalidadesByMunicipioQuery : IRequest<List<LocalidadeDto>>
{
    public required int Id { get; init; }
}

public class GetLocalidadesByMunicipioQueryHandler : IRequestHandler<GetLocalidadesByMunicipioQuery, List<LocalidadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLocalidadesByMunicipioQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LocalidadeDto>> Handle(GetLocalidadesByMunicipioQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _context.Localidades
                .Where(x => x.Municipio!.Id == request.Id)
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
