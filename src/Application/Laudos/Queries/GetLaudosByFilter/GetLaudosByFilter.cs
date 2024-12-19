using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Mappings;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Queries.GetLaudosByFilter;

public record GetLaudosByFilterQuery : IRequest<PaginatedList<LaudoDto>>
{
    public required LaudosFilterDto SearchFilter { get; init; }
}

public class GetLaudosByFilterQueryHandler : IRequestHandler<GetLaudosByFilterQuery, PaginatedList<LaudoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLaudosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<LaudoDto>> Handle(GetLaudosByFilterQuery request, CancellationToken cancellationToken)
    {
        var laudos = _context.Laudos
            .Include(i => i.Aluno.Localidade)
            .Include(i => i.QualidadeDeVida)
            .Include(i => i.Vocacional)
            .Include(i => i.ConsumoAlimentar)
            .Include(i => i.TalentoEsportivo)
            .Include(i => i.Saude)
            .Include(i => i.SaudeBucal)
            .AsNoTracking();

        var result = FilterLaudos(laudos, request.SearchFilter!, cancellationToken)
            .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
            .OrderByDescending(t => t.Id)
            .PaginatedListAsync(request.SearchFilter.PageNumber, request.SearchFilter.PageSize);

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Laudo> FilterLaudos(IQueryable<Laudo> laudos, LaudosFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = Convert.ToInt32(search.FomentoId);

            laudos = laudos.Where(u => u.Aluno.Fomento!.Id == fomento);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            laudos = laudos.Where(u => u.Aluno.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            laudos = laudos.Where(u => u.Aluno.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            laudos = laudos.Where(u => u.Aluno.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.AlunoId))
        {
            laudos = laudos.Where(u => u.Aluno.Id == Convert.ToInt32(search.AlunoId));
        }

        if (!string.IsNullOrWhiteSpace(search.TipoLaudoId))
        {
            laudos = Convert.ToInt32(search.TipoLaudoId) switch
            {
                (int)EnumTipoLaudo.ConsumoAlimentar => laudos.Where(u => u.ConsumoAlimentar != null),
                (int)EnumTipoLaudo.QualidadeVida => laudos.Where(u => u.QualidadeDeVida != null),
                (int)EnumTipoLaudo.Saude => laudos.Where(u => u.Saude != null),
                (int)EnumTipoLaudo.SaudeBucal => laudos.Where(u => u.SaudeBucal != null),
                (int)EnumTipoLaudo.TalentoEsportivo => laudos.Where(u => u.TalentoEsportivo != null),
                (int)EnumTipoLaudo.Vocacional => laudos.Where(u => u.Vocacional != null),
                _ => laudos
            };
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            laudos = laudos.Where(u => u.Aluno!.Deficiencia!.Id == Convert.ToInt32(search.DeficienciaId));
        }

        if (search.PossuiFoto)
        {
            laudos = laudos.Where(u => u.Aluno.ByteImage != null);
        }

        if (search.Finalizado)
        {
            laudos = laudos.Where(u => u.StatusLaudo == "F");
        }

        return laudos;
    }
}
