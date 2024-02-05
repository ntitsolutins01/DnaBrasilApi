using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.Fomentos.Queries;
using DnaBrasilApi.Domain.Entities;
using MediatR;

namespace DnaBrasilApi.Application.Alunos.Queries.GetIndicadoresAlunosByFilter;
//[Authorize]
public record GetIndicadoresAlunosByFilterQuery : IRequest<int>
{
    public DashboardIndicadoresDto? SearchFilter { get; init; }

}

public class GetIndicadoresAlunosByFilterQueryHandler : IRequestHandler<GetIndicadoresAlunosByFilterQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetIndicadoresAlunosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<int> Handle(GetIndicadoresAlunosByFilterQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> Alunos;

        Alunos = string.IsNullOrWhiteSpace(request.SearchFilter!.Sexo)
            ? _context.Alunos
                .AsNoTracking()
            : _context.Alunos
                .Where(x => x.Sexo == request.SearchFilter!.Sexo)
                .AsNoTracking();

        var result = FilterAlunos(Alunos, request.SearchFilter!, cancellationToken);
            
        return Task.FromResult((result));
    }

    private int FilterAlunos(IQueryable<Aluno> Alunos, DashboardIndicadoresDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = _context.Fomentos.Where(x => x.Id == Convert.ToInt32(search.FomentoId))
                .AsNoTracking()
                .ProjectTo<FomentoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken); 

            Alunos = Alunos.Where(u => u.Municipio!.Id.Equals(fomento.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            Alunos = Alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            Alunos = Alunos.Where(u => u.Municipio!.Id.Equals(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            Alunos = Alunos.Where(u => u.Localidade!.Id.Equals(search.LocalidadeId));
        }

        return Alunos.Count();
    }
}

