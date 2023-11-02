using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Estados.Queries.GetEstadosAll;
public class EstadoDto
{
    public int Id { get; init; }
    public string? Sigla { get; init; }
    public string? Nome { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Estado, EstadoDto>();
        }
    }
}
