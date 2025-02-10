using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Queries.GetModeloCarteirinhaById;

public record GetModeloCarteirinhaByIdQuery : IRequest<ModeloCarteirinhaDto>
{
    public required int Id { get; init; }
}

public class GetModeloCarteirinhaByIdQueryHandler : IRequestHandler<GetModeloCarteirinhaByIdQuery, ModeloCarteirinhaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModeloCarteirinhaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModeloCarteirinhaDto> Handle(GetModeloCarteirinhaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ModelosCarteirinhas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ModeloCarteirinhaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
