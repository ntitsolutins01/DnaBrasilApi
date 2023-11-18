using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunosByFilter;

public record GetAlunosByFilterQuery : IRequest<List<AlunoDto>>
{
    public SearchAlunosDto? Search { get; init; }
}

public class GetAlunosByFilterQueryHandler : IRequestHandler<GetAlunosByFilterQuery, List<AlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoDto>> Handle(GetAlunosByFilterQuery request, CancellationToken cancellationToken)
    {
        var Alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunos(Alunos, request.Search!)
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken); ;

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Aluno> FilterAlunos(IQueryable<Aluno> Alunos, SearchAlunosDto search)
    {
        if (!string.IsNullOrWhiteSpace(search.Nome))
            Alunos = Alunos.Where(u => u.Nome.Contains(search.Nome));

        if (!string.IsNullOrWhiteSpace(search.Cpf))
            Alunos = Alunos.Where(u => u.Cpf!.Contains(search.Cpf));

        if (search.DeficienciaId.GetValueOrDefault() != 0)
            Alunos = Alunos.Where(u => u.Deficiencias!.Any(f => f.Id == search.DeficienciaId));

        //TODO: Relacionamento Aluno-Local para filtro
        //if (search.LocalId.GetValueOrDefault() != 0)
        //    Alunos = Alunos.Where(u => u.Local!.Any(f => f.Id == search.LocalId));

        return Alunos;
    }
}
