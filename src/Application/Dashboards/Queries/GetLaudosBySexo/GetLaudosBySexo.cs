using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetLaudosBySexo;

public record GetLaudosBySexoQuery : IRequest<int>
{
    public string? Sexo { get; init; }
}

public class GetLaudosBySexoQueryHandler : IRequestHandler<GetLaudosBySexoQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLaudosBySexoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(GetLaudosBySexoQuery request, CancellationToken cancellationToken)
    {
        int result = 0;

        result = string.IsNullOrWhiteSpace(request.Sexo)
            ? await _context.Laudos
                .AsNoTracking()
                .CountAsync(cancellationToken)
            : await _context.Laudos
                .Where(x => x.Aluno.Sexo == request.Sexo)
                .AsNoTracking()
                .CountAsync(cancellationToken);

        return result;
    }
}
