using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Respostas.Queries.GetRespostaByQuestionario;

public record GetRespostaByTipoLaudoQuery : IRequest<List<RespostaDto>>
{
    public required int QuestionarioId { get; init; }
}

public class GetRespostaByTipoLaudoQueryHandler : IRequestHandler<GetRespostaByTipoLaudoQuery, List<RespostaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRespostaByTipoLaudoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RespostaDto>> Handle(GetRespostaByTipoLaudoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Respostas
            .Where(x => x.Questionario!.Id == request.QuestionarioId)
            .AsNoTracking()
            .ProjectTo<RespostaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result;
    }
}
