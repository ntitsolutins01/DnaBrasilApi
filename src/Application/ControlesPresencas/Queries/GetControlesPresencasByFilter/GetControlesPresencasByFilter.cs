using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Mappings;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByFilter;

public record GetControlesPresencasByFilterQuery : IRequest<PaginatedList<ControlePresencaDto>>
{
    public required ControlesPresencasFilterDto SearchFilter { get; init; }
}

public class GetControlesPresencasByFilterQueryHandler : IRequestHandler<GetControlesPresencasByFilterQuery, PaginatedList<ControlePresencaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesPresencasByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ControlePresencaDto>> Handle(GetControlesPresencasByFilterQuery request, CancellationToken cancellationToken)
    {
        var ControlePresencas = _context.ControlesPresencas
            .Include(i=>i.Evento)
            .Where(x=>x.Evento==null)
            .AsNoTracking();

        var result = FilterControlePresencas(ControlePresencas, request.SearchFilter!, cancellationToken)
            .ProjectTo<ControlePresencaDto>(_mapper.ConfigurationProvider)
            .OrderByDescending(t => t.Id)
            .PaginatedListAsync(request.SearchFilter.PageNumber, request.SearchFilter.PageSize);

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
