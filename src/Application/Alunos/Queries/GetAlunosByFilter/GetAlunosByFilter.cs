using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using MediatR;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunosByFilter;

public record GetAlunosByFilterQuery : IRequest<List<AlunoIndexDto>>
{
    public AlunosFilterDto? SearchFilter { get; init; }
}

public class GetAlunosByFilterQueryHandler : IRequestHandler<GetAlunosByFilterQuery, List<AlunoIndexDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoIndexDto>> Handle(GetAlunosByFilterQuery request, CancellationToken cancellationToken)
    {
        var Alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunos(Alunos, request.SearchFilter!, cancellationToken)
            .ProjectTo<AlunoIndexDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken); ;

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Aluno> FilterAlunos(IQueryable<Aluno> Alunos, AlunosFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            Alunos = Alunos.Where(u => u.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }
        else
        {

            if (!string.IsNullOrWhiteSpace(search.MunicipioId))
            {
                Alunos = Alunos.Where(u => u.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
            }
            else
            {

                if (!string.IsNullOrWhiteSpace(search.Estado))
                {
                    Alunos = Alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado));
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(search.FomentoId))
                    {
                        var fomento = Convert.ToInt32(search.FomentoId);

                        Alunos = Alunos.Where(u => u.Fomento!.Id == fomento);
                    }

                }
            }
        }

        if (!string.IsNullOrWhiteSpace(search.AlunoId))
        {
            var alunoId = Convert.ToInt32(search.AlunoId);

            Alunos = Alunos.Where(u => u.Id == alunoId);
        }

        if (!string.IsNullOrWhiteSpace(search.Nome))
        {
            Alunos = Alunos.Where(u => u.Nome.Contains(search.Nome));
        }

        if (!string.IsNullOrWhiteSpace(search.ProfissionalId))
        {
            Alunos = Alunos.Where(u => u.Profissional!.Id == Convert.ToInt32(search.ProfissionalId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

            Alunos = Alunos.Where(u => listAlunos.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            Alunos = Alunos.Where(u => u.Etnia!.Equals(search.Etnia));
        }

        if (!string.IsNullOrWhiteSpace(search.Matricula))
        {
            var matricula = Convert.ToInt32(search.Matricula);

            Alunos = Alunos.Where(u => u.Id == matricula);
        }

        if (!string.IsNullOrWhiteSpace(search.Sexo))
        {
            Alunos = Alunos.Where(u => u.Sexo!.Equals(search.Sexo));
        }

        if (search.PossuiFoto)
        {
            Alunos = Alunos.Where(u => u.ByteImage != null);
        }

        if (!string.IsNullOrWhiteSpace(search.SerieId))
        {
            var serieId = Convert.ToInt32(search.SerieId);

            Alunos = Alunos.Where(u => u.Serie != null && u.Serie.Id == serieId);
        }

        if (!string.IsNullOrWhiteSpace(search.Email))
        {
            Alunos = Alunos.Where(u => u.Email.Trim().ToUpper() == search.Email.Trim().ToUpper());
        }

        if (!string.IsNullOrWhiteSpace(search.DataNascimento))
        {
            var data = DateTime.ParseExact(search.DataNascimento, "dd/MM/yyyy",
                CultureInfo.CreateSpecificCulture("pt-BR"));

            Alunos = Alunos.Where(u => u.DtNascimento == data);
        }

        if (!string.IsNullOrWhiteSpace(search.Cpf))
        {
            Alunos = Alunos.Where(u => u.Cpf == search.Cpf);
        }

        return Alunos;
    }
}
