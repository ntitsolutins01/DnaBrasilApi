using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Mappings;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Eventos.Queries.GetEventosByFilter;

public record GetEventosByFilterQuery : IRequest<PaginatedList<EventoDto>>
{
    public required EventosFilterDto SearchFilter { get; init; }
}

public class GetEventosByFilterQueryHandler : IRequestHandler<GetEventosByFilterQuery, PaginatedList<EventoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEventosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<EventoDto>> Handle(GetEventosByFilterQuery request, CancellationToken cancellationToken)
    {
        var Eventos = _context.Eventos
            .AsNoTracking();

        var result = FilterEventos(Eventos, request.SearchFilter!, cancellationToken)
            .ProjectTo<EventoDto>(_mapper.ConfigurationProvider)
            .OrderByDescending(t => t.Id)
            .PaginatedListAsync(request.SearchFilter.PageNumber, request.SearchFilter.PageSize);

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Evento> FilterEventos(IQueryable<Evento> Eventos, EventosFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            Eventos = Eventos.Where(u => u.Localidade.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            Eventos = Eventos.Where(u => u.Localidade.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }


        return Eventos;
    }
}
