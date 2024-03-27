using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Security;
using DnaBrasilApi.Domain.Constants;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunosAll;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.Consultar)]
public record GetAlunosAllQuery : IRequest<List<AlunoDto>>;

public class GetAlunosAllQueryHandler : IRequestHandler<GetAlunosAllQuery, List<AlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoDto>> Handle(GetAlunosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .AsNoTracking()
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

