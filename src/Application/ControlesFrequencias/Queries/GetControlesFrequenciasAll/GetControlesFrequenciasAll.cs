using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Mappings;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Application.ControlesFrequencias.Queries;

namespace DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControlesFrequenciasAll;
//[Authorize]
public record GetControlesFrequenciasAllQuery : IRequest<PaginatedList<ControleFrequenciaDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetControlesFrequenciasAllQueryHandler : IRequestHandler<GetControlesFrequenciasAllQuery, PaginatedList<ControleFrequenciaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesFrequenciasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ControleFrequenciaDto>> Handle(GetControlesFrequenciasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesFrequencias
            .Include(i => i.Disciplina)
            .AsNoTracking()
            .ProjectTo<ControleFrequenciaDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
