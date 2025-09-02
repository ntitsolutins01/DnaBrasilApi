using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Queries.GetModeloCarteirinhaByFomentoId;

public record GetModeloCarteirinhaByFomentoIdQuery : IRequest<ModeloCarteirinhaDto>
{
    public required int FomentoId { get; init; }
}

public class GetModeloCarteirinhaByFomentoIdQueryHandler : IRequestHandler<GetModeloCarteirinhaByFomentoIdQuery, ModeloCarteirinhaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModeloCarteirinhaByFomentoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModeloCarteirinhaDto> Handle(GetModeloCarteirinhaByFomentoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ModelosCarteirinhas
            .Where(x => x.Fomento!.Id == request.FomentoId)
            .AsNoTracking()
            .ProjectTo<ModeloCarteirinhaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (result == null)
        {
            throw new KeyNotFoundException($"ModeloCarteirinha with FomentoId {request.FomentoId} not found.");
        }

        return result;
    }
}
