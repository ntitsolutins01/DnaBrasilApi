using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControlesFrequenciasByAlunoId;

public record GetControlesFrequenciasByAlunoIdQuery : IRequest<List<ControleFrequenciaAlunoDto>>
{
    public required int AlunoId { get; init; }
}

public class GetControlesFrequenciasByAlunoIdQueryHandler : IRequestHandler<GetControlesFrequenciasByAlunoIdQuery, List<ControleFrequenciaAlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesFrequenciasByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleFrequenciaAlunoDto>> Handle(GetControlesFrequenciasByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .Where(a => a.Id == request.AlunoId)
            .Include(a => a.Municipio)
            .ThenInclude(m => m.Estado)
            .Include(a => a.Localidade)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (aluno == null)
        {
            return new List<ControleFrequenciaAlunoDto>(); 
        }

        var controlesFrequencias = await _context.ControlesFrequencias
            .Where(cp => cp.Aluno != null && cp.Aluno.Id == request.AlunoId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var result = new ControleFrequenciaAlunoDto
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
            ControlesFrequencias = controlesFrequencias
                .Select(cp => new ControlesFrequenciasDto
                {
                    Id = cp.Id,
                    DisciplinaId = cp.Disciplina.Id,
                    Presenca = cp.Presenca,
                    Justificativa = cp.Justificativa,
                    Data = cp.Created.ToString("dd/MM/yyyy"),
                    Status = cp.Status
                }).ToList()
        };

        return new List<ControleFrequenciaAlunoDto> { result };
    }
}
