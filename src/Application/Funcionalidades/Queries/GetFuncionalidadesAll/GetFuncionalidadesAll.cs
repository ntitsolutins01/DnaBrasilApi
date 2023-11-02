//using DnaBrasil.Application.Common.Interfaces;

//namespace DnaBrasil.Application.Funcionalidades.Queries.GetFuncionalidadesAll;
////[Authorize]
//public record GetFuncionalidadesAllQuery : IRequest<List<FuncionalidadeDto>>;

//public class GetFuncionalidadesAllQueryHandler : IRequestHandler<GetFuncionalidadesAllQuery, List<FuncionalidadeDto>>
//{
//    private readonly IApplicationDbContext _context;
//    private readonly IMapper _mapper;

//    public GetFuncionalidadesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
//    {
//        _context = context;
//        _mapper = mapper;
//    }

//    public async Task<List<FuncionalidadeDto>> Handle(GetFuncionalidadesAllQuery request, CancellationToken cancellationToken)
//    {
//        var result = await _context.Funcionalidades
//            .AsNoTracking()
//            .ProjectTo<FuncionalidadeDto>(_mapper.ConfigurationProvider)
//            .OrderBy(t => t.Id)
//            .ToListAsync(cancellationToken);

//        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
//    }
//}
