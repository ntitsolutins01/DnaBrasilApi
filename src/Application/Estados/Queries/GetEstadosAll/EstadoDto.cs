using DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudos;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Estados.Queries.GetEstadosAll;
public class EstadoDto
{
    public int Id { get; init; }
    public string? Sigla { get; set; }
    public string? Nome { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Estado, EstadoDto>();
        }
    }
}
