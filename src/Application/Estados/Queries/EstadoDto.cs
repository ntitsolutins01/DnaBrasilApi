using DnaBrasilApi.Application.Municipios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Estados.Queries;
public class EstadoDto
{
    public int Id { get; init; }
    public string? Sigla { get; init; }
    public string? Nome { get; init; }
    public List<MunicipioDto>? Municipios { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Estado, EstadoDto>();
        }
    }
}
