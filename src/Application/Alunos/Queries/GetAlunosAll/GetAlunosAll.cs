using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Alunos.Queries.GetAlunosAll;

namespace DnaBrasil.Application.Alunos.Queries.GetAlunosAll;
//[Authorize]
public record GetAlunosQuery : IRequest<List<AlunoDto>>;

public class GetAlunosQueryHandler : IRequestHandler<GetAlunosQuery, List<AlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoDto>> Handle(GetAlunosQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .AsNoTracking()
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

