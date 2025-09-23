using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEducacionaisByAluno;

public record GetEducacionaisByAlunoQuery : IRequest<List<EducacionalDto>>
{
    public required int AlunoId { get; init; }
}

public class GetEducacionaisByAlunoQueryHandler : IRequestHandler<GetEducacionaisByAlunoQuery, List<EducacionalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEducacionaisByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EducacionalDto>> Handle(GetEducacionaisByAlunoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Educacionais
            .Where(ac => ac.Aluno.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<EducacionalDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result ?? throw new ArgumentNullException(nameof(result));
    }
}
