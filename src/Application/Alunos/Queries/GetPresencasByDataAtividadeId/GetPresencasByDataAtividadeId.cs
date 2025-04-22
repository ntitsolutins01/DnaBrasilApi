using System.Globalization;
using DnaBrasilApi.Application.Atividades.Queries;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetPresencasByDataAtividadeId;

public record GetPresencasByDataAtividadeIdQuery : IRequest<List<AtividadeDto>>
{
    public required string Data { get; init; }
    public required int AtividadeId { get; init; }
}

public class GetPresencasByDataAtividadeIdQueryHandler : IRequestHandler<GetPresencasByDataAtividadeIdQuery, List<AtividadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPresencasByDataAtividadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AtividadeDto>> Handle(GetPresencasByDataAtividadeIdQuery request, CancellationToken cancellationToken)
    {
        var data = DateTime.ParseExact(request.Data, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));

        var result = await _context.AlunosPresencas
            .Where(ac => ac.Data == data && ac.AtividadeId == request.AtividadeId)
            .Include(ac => ac.Atividade)
            .AsNoTracking()
            .Select(ac => ac.Atividade)
            .ProjectTo<AtividadeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result ?? throw new ArgumentNullException(nameof(result));
    }
}
