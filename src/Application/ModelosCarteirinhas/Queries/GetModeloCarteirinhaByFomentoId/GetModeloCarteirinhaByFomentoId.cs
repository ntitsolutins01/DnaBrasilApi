using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Queries.GetModeloCarteirinhaByQuestionario;

public record GetModeloCarteirinhaByFomentoIdQuery : IRequest<List<ModeloCarteirinhaDto>>
{
    public required int FomentoId { get; init; }
}

public class GetModeloCarteirinhaByFomentoIdQueryHandler : IRequestHandler<GetModeloCarteirinhaByFomentoIdQuery, List<ModeloCarteirinhaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModeloCarteirinhaByFomentoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModeloCarteirinhaDto>> Handle(GetModeloCarteirinhaByFomentoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ModelosCarteirinhas
            .Where(x => x.Fomento!.Id == request.FomentoId)
            .AsNoTracking()
            .ProjectTo<ModeloCarteirinhaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result;
    }
}
