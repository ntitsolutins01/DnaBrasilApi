using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetLaudoByAluno
{
    public record GetLaudoByAlunoQuery(int AlunoId) : IRequest<LaudoDto>;

    public class GetLaudoByAlunoQueryHandler : IRequestHandler<GetLaudoByAlunoQuery, LaudoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLaudoByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LaudoDto> Handle(GetLaudoByAlunoQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Laudos
                .AsNoTracking()
                .Where(x => x.Aluno.Id == request.AlunoId) 
                .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return result == null ? throw new ArgumentNullException(nameof(result)) : result;
        }
    }
}
