using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Mappings;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Application.ControlesFrequencias.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControlesFrequenciasByFilter;

public record GetControlesFrequenciasByFilterQuery : IRequest<PaginatedList<ControleFrequenciaDto>>
{
    public required ControlesFrequenciasFilterDto SearchFilter { get; init; }
}

public class GetControlesFrequenciasByFilterQueryHandler : IRequestHandler<GetControlesFrequenciasByFilterQuery, PaginatedList<ControleFrequenciaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesFrequenciasByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ControleFrequenciaDto>> Handle(GetControlesFrequenciasByFilterQuery request, CancellationToken cancellationToken)
    {
        var ControleFrequencias = _context.ControlesFrequencias
            .Include(i=>i.Disciplina)
            .AsNoTracking();

        var result = FilterControleFrequencias(ControleFrequencias, request.SearchFilter!, cancellationToken)
            .ProjectTo<ControleFrequenciaDto>(_mapper.ConfigurationProvider)
            .OrderByDescending(t => t.Id)
            .PaginatedListAsync(request.SearchFilter.PageNumber, request.SearchFilter.PageSize);

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<ControleFrequencia> FilterControleFrequencias(IQueryable<ControleFrequencia> ControleFrequencias, ControlesFrequenciasFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = _context.Fomentos.Include(i=>i.Municipio).First(x => x.Id == Convert.ToInt32(search.FomentoId));

            ControleFrequencias = ControleFrequencias.Where(u => u.Aluno.Municipio!.Id == fomento.Municipio!.Id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            ControleFrequencias = ControleFrequencias.Where(u => u.Aluno.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            ControleFrequencias = ControleFrequencias.Where(u => u.Aluno.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            ControleFrequencias = ControleFrequencias.Where(u => u.Aluno.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listControleFrequencias = deficiencias.Alunos!.Select(s => s.Id).ToList();

            ControleFrequencias = ControleFrequencias.Where(u => listControleFrequencias.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            ControleFrequencias = ControleFrequencias.Where(u => u.Aluno.Etnia!.Equals(search.Etnia));
        }

        return ControleFrequencias;
    }
}
