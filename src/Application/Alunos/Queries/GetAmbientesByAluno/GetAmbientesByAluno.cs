using DnaBrasil.Application.Ambientes.Queries.GetAmbientesAll;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Queries.GetAmbientesByAluno;

public record GetAmbientesByAlunoQuery : IRequest<List<AmbienteDto>>
{
    public int AlunoId { get; set; }
}

public class GetAmbientesByAlunoQueryHandler : IRequestHandler<GetAmbientesByAlunoQuery, List<AmbienteDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAmbientesByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AmbienteDto>> Handle(GetAmbientesByAlunoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .Where(x => x.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        

        return result!.Ambientes == null ? throw new ArgumentNullException(nameof(result.Ambientes)) : result.Ambientes;
    }
}
