using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Mappings;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Queries.GetLaudosResumidosByFilter;

public record GetLaudosResumidosByFilterQuery : IRequest<List<LaudoResumidoDto>>
{
    public required LaudosResumidosFilterDto SearchFilter { get; init; }
}

public class GetLaudosResumidosByFilterQueryHandler : IRequestHandler<GetLaudosResumidosByFilterQuery, List<LaudoResumidoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLaudosResumidosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LaudoResumidoDto>> Handle(GetLaudosResumidosByFilterQuery request, CancellationToken cancellationToken)
    {
        var laudos = _context.Laudos
            .Include(i => i.Aluno.Localidade)
            .Include(i => i.QualidadeDeVida)
            .Include(i => i.ConsumoAlimentar)
            .Include(i => i.TalentoEsportivo)
            .Include(i => i.Saude)
            .Include(i => i.SaudeBucal)
            .Include(i => i.Vocacional)
            .Include(i => i.Modalidade)
            .AsNoTracking()
            .Where(x => x.Modalidade != null && x.StatusLaudo == "F" &&
                        x.Aluno.Localidade!.Id == Convert.ToInt32(request.SearchFilter.LocalidadeId))
            .AsNoTracking();
        
        var result = await FilterLaudos(laudos, request.SearchFilter!, cancellationToken)
                .ProjectTo<LaudoResumidoDto>(_mapper.ConfigurationProvider)
                .OrderBy(o => o.TalentoEsportivo!.EncaminhamentoTexo)
                .ToListAsync();

        //.Where(x=>x.Modalidade != null &&
        //    x.Aluno.Localidade!.Id == Convert.ToInt32(request.SearchFilter.LocalidadeId) && 
        //    x.StatusLaudo == "F")
        //.ProjectTo<LaudoResumidoDto>(_mapper.ConfigurationProvider)
        //.ToListAsync();

        var count = result.Count;

        return result ?? throw new ArgumentNullException(nameof(result));
    }

    private IQueryable<Laudo> FilterLaudos(IQueryable<Laudo> laudos, LaudosResumidosFilterDto search, CancellationToken cancellationToken)
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
