using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetLaudoById
{
    public record GetLaudoByIdQuery(int Id) : IRequest<LaudoDto>;

    public class GetLaudoByIdQueryHandler : IRequestHandler<GetLaudoByIdQuery, LaudoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLaudoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LaudoDto> Handle(GetLaudoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Laudos
                .AsNoTracking()
                .Where(x => x.Id == request.Id) 
                .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return result == null ? throw new ArgumentNullException(nameof(result)) : result;
        }
    }
}
