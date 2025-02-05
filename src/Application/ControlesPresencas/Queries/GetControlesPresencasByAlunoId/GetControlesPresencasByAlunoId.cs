using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByAlunoId;

public record GetControlesPresencasByAlunoIdQuery : IRequest<List<ControlePresencaAlunoDto>>
{
    public required int AlunoId { get; init; }
}

public class GetControlesPresencasByAlunoIdQueryHandler : IRequestHandler<GetControlesPresencasByAlunoIdQuery, List<ControlePresencaAlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesPresencasByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControlePresencaAlunoDto>> Handle(GetControlesPresencasByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        // 1. Buscar os dados do aluno (sem duplicações)
        var aluno = await _context.Alunos
            .Where(a => a.Id == request.AlunoId)
            .Include(a => a.Municipio)
            .ThenInclude(m => m.Estado)
            .Include(a => a.Localidade)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (aluno == null)
        {
            return new List<ControlePresencaAlunoDto>(); // Retorna lista vazia se o aluno não for encontrado
        }

        // 2. Buscar todos os controles de presença do aluno, garantindo que o Aluno não seja null
        var controlesPresencas = await _context.ControlesPresencas
            .Where(cp => cp.Aluno != null && cp.Aluno.Id == request.AlunoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        // 3. Montar o DTO do aluno com os controles de presença
        var result = new ControlePresencaAlunoDto
        {
            AlunoId = aluno.Id,
            NomeAluno = aluno.Nome,
            MunicipioId = aluno.Municipio?.Id ?? 0,
            MunicipioEstado = aluno.Municipio != null && aluno.Municipio.Estado != null
                ? $"{aluno.Municipio.Nome} / {aluno.Municipio.Estado.Sigla}"
                : "Sem município",
            LocalidadeId = aluno.Localidade?.Id ?? 0,
            NomeLocalidade = aluno.Localidade?.Nome ?? "Sem localidade",
            ByteImage = null/*aluno.ByteImage*/,
            ControlesPresencas = controlesPresencas
                .Select(cp => new ControlePresencaDto
                {
                    Id = cp.Id,
                    EventoId = cp.Evento?.Id ?? 0,
                    Controle = cp.Controle,
                    Justificativa = cp.Justificativa,
                    Data = cp.Created.ToString("dd/MM/yyyy"),
                    Status = cp.Status
                }).ToList()
        };

        return new List<ControlePresencaAlunoDto> { result };
    }
}
