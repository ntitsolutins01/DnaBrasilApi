using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.DocumentosAluno.Queries.GetDocumentoAlunoById;

public record GetDocumentoAlunoByIdQuery : IRequest<DocumentoAlunoDto>
{
    public required int Id { get; init; }
}

public class GetDocumentoAlunoByIdQueryHandler : IRequestHandler<GetDocumentoAlunoByIdQuery, DocumentoAlunoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDocumentoAlunoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DocumentoAlunoDto> Handle(GetDocumentoAlunoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.DocumentosAluno
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<DocumentoAlunoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
