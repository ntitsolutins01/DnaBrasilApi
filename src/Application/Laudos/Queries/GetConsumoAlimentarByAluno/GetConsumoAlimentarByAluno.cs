using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.GetConsumoAlimentarByAluno;

public record GetConsumoAlimentaresByAlunoQuery : IRequest<ConsumoAlimentarDto>
{
    public int AlunoId { get; set; }
}

public class GetConsumoAlimentaresByAlunoQueryHandler : IRequestHandler<GetConsumoAlimentaresByAlunoQuery, ConsumoAlimentarDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetConsumoAlimentaresByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ConsumoAlimentarDto> Handle(GetConsumoAlimentaresByAlunoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ConsumoAlimentares
            .Where(x => x.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<ConsumoAlimentarDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);


        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
