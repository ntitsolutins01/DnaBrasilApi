using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.DocumentosAluno.Queries.GetDocumentosAllByAlunoId;
//[Authorize]
public record GetDocumentosAllByAlunoIdQuery : IRequest<List<DocumentoAlunoDto>>
{
    public required int AlunoId { get; init; }
}

public class GetDocumentosAllByAlunoIdQueryHandler : IRequestHandler<GetDocumentosAllByAlunoIdQuery, List<DocumentoAlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDocumentosAllByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DocumentoAlunoDto>> Handle(GetDocumentosAllByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.DocumentosAluno
            .Where(x => x.Aluno.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<DocumentoAlunoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
