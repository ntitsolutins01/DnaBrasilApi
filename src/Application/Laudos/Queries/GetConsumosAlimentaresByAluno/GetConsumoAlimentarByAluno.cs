using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetConsumosAlimentaresByAluno;

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

        //var laudos = aluno.Laudos!.OrderByDescending(o => o.Created).AsQueryable();

        //var laudoRecente = await laudos
        //    .AsNoTracking()
        //    .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
        //    .FirstOrDefaultAsync(cancellationToken);

        var result = await _context.ConsumoAlimentares
            //.Where(x=>x.Id == laudoRecente!.ConsumoAlimentarId)
            .AsNoTracking()
            .ProjectTo<ConsumoAlimentarDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);


        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
