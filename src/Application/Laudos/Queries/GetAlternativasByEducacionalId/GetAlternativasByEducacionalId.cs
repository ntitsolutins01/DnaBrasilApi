using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetAlternativasByEducacionalId;

public record GetAlternativasByEducacionalIdQuery : IRequest<AlternativasDto>
{
    public required int EducacionalId { get; init; }
}

public class GetAlternativasByEducacionalIdQueryHandler
    : IRequestHandler<GetAlternativasByEducacionalIdQuery, AlternativasDto>
{
    private readonly IApplicationDbContext _context;

    public GetAlternativasByEducacionalIdQueryHandler(IApplicationDbContext context)
        => _context = context;

    public async Task<AlternativasDto> Handle(GetAlternativasByEducacionalIdQuery request,
    CancellationToken cancellationToken)
    {
        var educacional = await _context.Educacionais
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.Id == request.EducacionalId, cancellationToken);

        Guard.Against.NotFound(request.EducacionalId, educacional);

        var idList = (educacional.Respostas ?? string.Empty)
            .Split(new[] { ',' }, StringSplitOptions.TrimEntries)
            .Select(s => int.TryParse(s, out var id) ? id : 0)
            .ToList();

        if (idList.Count == 0)
            return new AlternativasDto { EducacionalId = request.EducacionalId, Alternativas = string.Empty };

        var idsValidos = idList.Where(id => id > 0).Distinct().ToList();

        var selecionadas = await _context.Respostas
            .Where(r => idsValidos.Contains(r.Id))
            .Select(r => new
            {
                RespostaId = r.Id,
                QuestionarioId = r.Questionario.Id
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var respostaParaQuestao = selecionadas.ToDictionary(x => x.RespostaId, x => x.QuestionarioId);

        var qIds = selecionadas.Select(x => x.QuestionarioId).Distinct().ToList();

        var todasOpcoes = await _context.Respostas
            .Where(r => qIds.Contains(r.Questionario.Id))
            .OrderBy(r => r.Questionario.Id)
            .ThenBy(r => r.Id)
            .Select(r => new { QuestionarioId = r.Questionario.Id, RespostaId = r.Id, r.RespostaQuestionario })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var opcoesPorQuestao = todasOpcoes
            .GroupBy(o => o.QuestionarioId)
            .ToDictionary(g => g.Key, g => g.ToList());

        var letras = new List<string>(idList.Count);
        foreach (var respostaId in idList)
        {
            if (respostaId == 0)
            {
                letras.Add("/"); // branco/inválido
                continue;
            }

            if (!respostaParaQuestao.TryGetValue(respostaId, out var qId) ||
                !opcoesPorQuestao.TryGetValue(qId, out var lista))
            {
                letras.Add("/"); // não encontrado / sem opções
                continue;
            }

            var idx = lista.FindIndex(o => o.RespostaId == respostaId);
            letras.Add(IdxToLetter(idx));
        }

        return new AlternativasDto
        {
            EducacionalId = request.EducacionalId,
            Alternativas = string.Join(", ", letras)
        };

        static string IdxToLetter(int idx) =>
            (idx >= 0 && idx <= 25) ? ((char)('A' + idx)).ToString() : "/";
    }
}
