using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Queries.GetQuestionarioByTipoLaudo;

public record GetQuestionarioByTipoLaudoQuery : IRequest<List<QuestionarioDto>>
{
    public required string? NomeLaudo { get; init; }
}

public class GetQuestionarioByTipoLaudoQueryHandler : IRequestHandler<GetQuestionarioByTipoLaudoQuery, List<QuestionarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionarioByTipoLaudoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuestionarioDto>> Handle(GetQuestionarioByTipoLaudoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Questionarios
            .Where(x => x.Tipo!.Nome == request.NomeLaudo)
            .AsNoTracking()
            .ProjectTo<QuestionarioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Tipo)
            .ToListAsync(cancellationToken);

        return result;
    }
}
