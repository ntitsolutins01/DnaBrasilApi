using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Municipios.Queries;

public class MunicipioDto
{
    public int Id { get; init; }
    public int CodigoIbge { get; init; }
    public string? Nome { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Municipio, MunicipioDto>();
        }
    }
}
