using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetAlunosBySexo;

public record GetAlunosBySexoQuery : IRequest<int>
{
    public string? Sexo { get; init; }
}

public class GetAlunosBySexoQueryHandler : IRequestHandler<GetAlunosBySexoQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosBySexoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(GetAlunosBySexoQuery request, CancellationToken cancellationToken)
    {
        int result = 0;

        result = string.IsNullOrWhiteSpace(request.Sexo)
            ? await _context.Alunos
                .AsNoTracking()
                .CountAsync(cancellationToken)
            : await _context.Alunos
                .Where(x => x.Sexo == request.Sexo)
                .AsNoTracking()
                .CountAsync(cancellationToken);

        return result;
    }
}
