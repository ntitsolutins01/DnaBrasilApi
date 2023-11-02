using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Municipios.Queries;

public class MunicipioDto
{
    public int Id { get; init; }
    public int Codigo { get; init; }
    public string? Nome { get; init; }
    public Estado? Estado { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Municipio, MunicipioDto>();
        }
    }
}
