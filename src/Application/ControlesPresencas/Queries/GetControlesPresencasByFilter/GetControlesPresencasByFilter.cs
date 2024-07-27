using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByFilter;

public record GetControlesPresencasByFilterQuery : IRequest<List<ControlePresencaDto>>
{
    public ControlesPresencasFilterDto? SearchFilter { get; init; }
}

public class GetControlesPresencasByFilterQueryHandler : IRequestHandler<GetControlesPresencasByFilterQuery, List<ControlePresencaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesPresencasByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControlePresencaDto>> Handle(GetControlesPresencasByFilterQuery request, CancellationToken cancellationToken)
    {
        var ControlePresencas = _context.ControlesPresencas
            .Include(i=>i.Evento)
            .Where(x=>x.Evento==null)
            .AsNoTracking();

        var result = FilterControlePresencas(ControlePresencas, request.SearchFilter!, cancellationToken)
            .ProjectTo<ControlePresencaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken); ;

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<ControlePresenca> FilterControlePresencas(IQueryable<ControlePresenca> ControlePresencas, ControlesPresencasFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = _context.Fomentos.Include(i=>i.Municipio).First(x => x.Id == Convert.ToInt32(search.FomentoId));

            ControlePresencas = ControlePresencas.Where(u => u.Aluno.Municipio!.Id == fomento.Municipio!.Id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            ControlePresencas = ControlePresencas.Where(u => u.Aluno.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            ControlePresencas = ControlePresencas.Where(u => u.Aluno.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            ControlePresencas = ControlePresencas.Where(u => u.Aluno.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listControlePresencas = deficiencias.Alunos!.Select(s => s.Id).ToList();

            ControlePresencas = ControlePresencas.Where(u => listControlePresencas.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            ControlePresencas = ControlePresencas.Where(u => u.Aluno.Etnia!.Equals(search.Etnia));
        }

        return ControlePresencas;
    }
}
