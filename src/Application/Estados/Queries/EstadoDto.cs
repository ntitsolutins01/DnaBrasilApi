using DnaBrasilApi.Application.Municipios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Estados.Queries;
public class EstadoDto
{
    public int Id { get; init; }
    public string? Sigla { get; init; }
    public string? Nome { get; init; }
    public required int CodigoIbge { get; init; }
    public List<MunicipioDto>? Municipios { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Estado, EstadoDto>();
        }
    }
}
