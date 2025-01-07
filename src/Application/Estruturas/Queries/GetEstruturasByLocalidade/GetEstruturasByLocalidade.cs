using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Estruturas.Queries.GetEstruturasByLocalidade;

public record GetEstruturasByLocalidadeQuery : IRequest<List<EstruturaDto>>
{
    public required int LocalidadeId { get; init; }
}

public class GetEstruturasByLocalidadeQueryHandler : IRequestHandler<GetEstruturasByLocalidadeQuery, List<EstruturaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstruturasByLocalidadeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EstruturaDto>> Handle(GetEstruturasByLocalidadeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _context.Estruturas
                .Where(x => x.Localidade!.Id == request.LocalidadeId)
                .AsNoTracking()
                .ProjectTo<EstruturaDto>(_mapper.ConfigurationProvider)
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
