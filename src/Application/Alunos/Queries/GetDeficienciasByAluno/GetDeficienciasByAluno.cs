using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Deficiencias.Queries.GetDeficienciasAll;

namespace DnaBrasil.Application.Alunos.Queries.GetDeficienciasByAluno;

public record GetDeficienciasByAlunoQuery : IRequest<List<DeficienciaDto>>
{
    public int AlunoId { get; set; }
}

public class GetDeficienciasByAlunoQueryHandler : IRequestHandler<GetDeficienciasByAlunoQuery, List<DeficienciaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDeficienciasByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DeficienciaDto>> Handle(GetDeficienciasByAlunoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .Where(x => x.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);


        return result!.Deficiencias == null ? throw new ArgumentNullException(nameof(result.Deficiencias)) : result.Deficiencias;
    }
}
