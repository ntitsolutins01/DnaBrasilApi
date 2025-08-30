using DnaBrasilApi.Application.Cursos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TipoCursos.Queries;

public class TipoCursoDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; init; }
    public IList<CursoDto>? Cursos { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoCurso, TipoCursoDto>();
        }
    }
}
