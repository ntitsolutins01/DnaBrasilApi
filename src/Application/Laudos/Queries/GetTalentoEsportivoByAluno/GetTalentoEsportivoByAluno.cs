using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetVocacionalByAluno;

public record GetVocacionalByAlunoQuery : IRequest<VocacionalDto?>
{
    public int AlunoId { get; set; }
}

public class GetVocacionalByAlunoQueryHandler : IRequestHandler<GetVocacionalByAlunoQuery, VocacionalDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetVocacionalByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<VocacionalDto?> Handle(GetVocacionalByAlunoQuery request, CancellationToken cancellationToken)
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

        return result == null ? throw new ArgumentNullException(nameof(result)) : result.Vocacional;
    }
}
