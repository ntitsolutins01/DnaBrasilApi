using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Funcionalidades.Queries.GetFuncionalidadeById;

public record GetFuncionalidadeByIdQuery : IRequest<FuncionalidadeDto>
{
    public required int Id { get; init; }
}

public class GetFuncionalidadeByIdQueryHandler : IRequestHandler<GetFuncionalidadeByIdQuery, FuncionalidadeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFuncionalidadeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FuncionalidadeDto> Handle(GetFuncionalidadeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Funcionalidades
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<FuncionalidadeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
