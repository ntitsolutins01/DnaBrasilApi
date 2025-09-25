using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunoTurmaById;

public record GetAlunoTurmaByIdQuery : IRequest<AlunoTurmaDto>
{
    public required int Id { get; init; }
}

public class GetAlunoTurmaByIdQueryHandler : IRequestHandler<GetAlunoTurmaByIdQuery, AlunoTurmaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunoTurmaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AlunoTurmaDto> Handle(GetAlunoTurmaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<AlunoTurmaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
