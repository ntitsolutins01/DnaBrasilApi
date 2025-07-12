using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Cursos.Queries.GetQuantidadeCursosByProgresso;

public record GetQuantidadeCursosByProgressoQuery : IRequest<int>
{
    public required int ProgressoIni { get; init; } 
    public required int ProgressoFim { get; init; } 
};

public class GetQuantidadeCursosByProgressoQueryHandler : IRequestHandler<GetQuantidadeCursosByProgressoQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuantidadeCursosByProgressoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(GetQuantidadeCursosByProgressoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunoCursosCertificados
            .Where(x => x.Progresso > request.ProgressoIni && x.Progresso < request.ProgressoFim)
            .AsNoTracking()
            .CountAsync();

        return result;
    }
}
