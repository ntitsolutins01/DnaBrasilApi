using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TalentosEsportivos.Queries.GetTalentoEsportivoByAluno;

public record GetTalentoEsportivoByAlunoQuery(int AlunoId) : IRequest<List<TalentoEsportivoDto>>;

public class GetTalentoEsportivoByAlunoQueryHandler : IRequestHandler<GetTalentoEsportivoByAlunoQuery, List<TalentoEsportivoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTalentoEsportivoByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TalentoEsportivoDto>> Handle(GetTalentoEsportivoByAlunoQuery request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        //var laudos = aluno.Laudos!.OrderByDescending(o => o.Created).AsQueryable();

        //var laudoRecente = await laudos
        //    .AsNoTracking()
        //    .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
        //    .FirstOrDefaultAsync(cancellationToken);

        var result = await _context.TalentosEsportivos
            .Where(x => x.Aluno!.Id == request.AlunoId)
            .Include(i => i.Profissional)
            .AsNoTracking()
            .ProjectTo<TalentoEsportivoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
