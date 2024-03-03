using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunosByLocalidade;

public record GetAlunosByLocalidadeQuery : IRequest<List<AlunoDto>>
{
    public required int LocalidadeId { get; init; }
}

public class GetAlunosByLocalidadeQueryHandler : IRequestHandler<GetAlunosByLocalidadeQuery, List<AlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosByLocalidadeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoDto>> Handle(GetAlunosByLocalidadeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _context.Alunos
                .Where(x => x.Localidade!.Id == request.LocalidadeId)
                .AsNoTracking()
                .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Nome)
                .ToListAsync(cancellationToken);

            return result;
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
            throw;
        }
    }
}
