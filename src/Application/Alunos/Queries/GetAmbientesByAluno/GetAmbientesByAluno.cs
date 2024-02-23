using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Modalidades.Queries;

namespace DnaBrasilApi.Application.Alunos.Queries.GetModalidadesByAluno;

public record GetModalidadesByAlunoQuery : IRequest<List<ModalidadeDto>>
{
    public int AlunoId { get; set; }
}

public class GetModalidadesByAlunoQueryHandler : IRequestHandler<GetModalidadesByAlunoQuery, List<ModalidadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModalidadesByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModalidadeDto>> Handle(GetModalidadesByAlunoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Modalidades
            .Where(x => x.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<ModalidadeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
