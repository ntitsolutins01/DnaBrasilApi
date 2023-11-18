using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Deficiencias.Queries.GetDeficienciasAll;

namespace DnaBrasilApi.Application.Alunos.Queries.GetMatriculaByAluno;

public record GetMatriculaByAlunoQuery : IRequest<MatriculaDto>
{
    public int AlunoId { get; set; }
}

public class GetMatriculaByAlunoQueryHandler : IRequestHandler<GetMatriculaByAlunoQuery, MatriculaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMatriculaByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MatriculaDto> Handle(GetMatriculaByAlunoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .Where(x => x.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);


        return result!.Matricula == null ? throw new ArgumentNullException(nameof(result.Matricula)) : result.Matricula;
    }
}
