using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetConsumoAlimentarByAluno;

public record GetConsumoAlimentaresByAlunoQuery : IRequest<ConsumoAlimentarDto?>
{
    public int AlunoId { get; set; }
}

public class GetConsumoAlimentaresByAlunoQueryHandler : IRequestHandler<GetConsumoAlimentaresByAlunoQuery, ConsumoAlimentarDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetConsumoAlimentaresByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ConsumoAlimentarDto?> Handle(GetConsumoAlimentaresByAlunoQuery request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
                .FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        var laudos = aluno.Laudos!.OrderByDescending(o => o.Created).AsQueryable();

        var result = await laudos
            .AsNoTracking()
            .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.AlunoId, result);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result.ConsumoAlimentar;
    }
}
