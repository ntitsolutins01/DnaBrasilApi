using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TipoCursos.Queries;

public class TipoCursoDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoCurso, TipoCursoDto>();
        }
    }
}
