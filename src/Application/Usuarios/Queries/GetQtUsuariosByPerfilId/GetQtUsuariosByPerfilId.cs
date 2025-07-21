using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Usuarios.Queries.GetQtUsuariosByPerfilId;
//[Authorize]
public record GetQtUsuariosByPerfilIdQuery : IRequest<int>
{
    public DashboardEadDto? SearchFilter { get; init; }
};

public class GetQtUsuariosByPerfilIdQueryHandler : IRequestHandler<GetQtUsuariosByPerfilIdQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQtUsuariosByPerfilIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<int> Handle(GetQtUsuariosByPerfilIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> Alunos;

        Alunos = string.IsNullOrWhiteSpace(request.SearchFilter!.Sexo)
            ? _context.Alunos
                .Where(x => x.Convidado == false && x.AspNetUserId != null)
                .AsNoTracking()
            : _context.Alunos
                .Where(x => x.Sexo == request.SearchFilter!.Sexo && x.Convidado == false && x.AspNetUserId != null)
                .AsNoTracking();

        var result = FilterAlunos(Alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private int FilterAlunos(IQueryable<Aluno> Alunos, DashboardEadDto search, CancellationToken cancellationToken)
    {
        switch (string.IsNullOrWhiteSpace(search.FomentoId))
        {
            case false:
                {
                    var id = Convert.ToInt32(search.FomentoId?.Split("-")[0]);

                    Alunos = Alunos.Where(u => u.Fomento.Id == id);
                    break;
                }
        }

        Alunos = string.IsNullOrWhiteSpace(search.Estado) switch
        {
            false => Alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado!)),
            _ => Alunos
        };

        Alunos = string.IsNullOrWhiteSpace(search.MunicipioId) switch
        {
            false => Alunos.Where(u => u.Municipio!.Id == Convert.ToInt32(search.MunicipioId)),
            _ => Alunos
        };

        Alunos = string.IsNullOrWhiteSpace(search.LocalidadeId) switch
        {
            false => Alunos.Where(u => u.Localidade!.Id == Convert.ToInt32(search.LocalidadeId)),
            _ => Alunos
        };

        switch (string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            case false:
                {
                    var deficiencias = _context.Deficiencias
                        .Include(i => i.Alunos)
                        .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

                    var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

                    Alunos = Alunos.Where(u => listAlunos.Contains(u.Id));
                    break;
                }
        }

        Alunos = string.IsNullOrWhiteSpace(search.Etnia) switch
        {
            false => Alunos.Where(u => u.Etnia!.Equals(search.Etnia)),
            _ => Alunos
        };

        switch (string.IsNullOrWhiteSpace(search.CursoId))
        {
            case false:
                {
                    var alunosCursos = _context.AlunoCursosCertificados.Where(x => x.CursoId == Convert.ToInt32(search.CursoId))
                        .Select(s => s.AlunoId).ToList();

                    Alunos = Alunos.Where(u => alunosCursos.Contains(u.Id));
                    break;
                }
        }

        return Alunos.Count();
    }
}
