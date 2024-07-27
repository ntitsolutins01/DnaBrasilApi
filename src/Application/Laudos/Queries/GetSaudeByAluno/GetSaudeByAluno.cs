using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetSaudeByAluno;

public record GetSaudeByAlunoQuery : IRequest<SaudeDto?>
{
    public int AlunoId { get; set; }
}

public class GetSaudeByAlunoQueryHandler : IRequestHandler<GetSaudeByAlunoQuery, SaudeDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSaudeByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SaudeDto?> Handle(GetSaudeByAlunoQuery request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        //var laudos = aluno.Laudos!.OrderByDescending(o => o.Created).AsQueryable();

        //var laudoRecente = await laudos
        //    .AsNoTracking()
        //    .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
        //    .FirstOrDefaultAsync(cancellationToken);

        var result = await _context.Saudes
            //.Where(x => x.Id == laudoRecente!.SaudeId)
            .AsNoTracking()
            .ProjectTo<SaudeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
