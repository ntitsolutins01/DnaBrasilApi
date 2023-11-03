using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Laudos.Queries.GetConsumoAlimentarByAluno;

namespace DnaBrasil.Application.Laudos.Queries.GetQualidadeVidaByAluno;

public record GetQualidadeDeVidaByAlunoQuery : IRequest<QualidadeDeVidaDto?>
{
    public int AlunoId { get; set; }
}

public class GetQualidadeDeVidaByAlunoQueryHandler : IRequestHandler<GetQualidadeDeVidaByAlunoQuery, QualidadeDeVidaDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQualidadeDeVidaByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<QualidadeDeVidaDto?> Handle(GetQualidadeDeVidaByAlunoQuery request, CancellationToken cancellationToken)
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

        return result == null ? throw new ArgumentNullException(nameof(result)) : result.QualidadeDeVida;
    }
}
