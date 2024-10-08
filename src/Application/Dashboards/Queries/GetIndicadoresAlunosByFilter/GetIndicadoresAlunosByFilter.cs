﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.Fomentos.Queries;
using DnaBrasilApi.Domain.Entities;
using MediatR;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetIndicadoresAlunosByFilter;
//[Authorize]
public record GetIndicadoresAlunosByFilterQuery : IRequest<int>
{
    public DashboardDto? SearchFilter { get; init; }

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

        return Task.FromResult(result);
    }

    private int FilterAlunos(IQueryable<Aluno> Alunos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            Alunos = Alunos.Where(u => u.Fomento.Id == id);
        }
        
        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            Alunos = Alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            Alunos = Alunos.Where(u => u.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            Alunos = Alunos.Where(u => u.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
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

        return Alunos.Count();
    }
}

