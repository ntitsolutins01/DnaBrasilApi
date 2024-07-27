using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TiposParcerias.Queries;
public class TipoParceriaDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int? Parceria { get; set; }
    public bool Status { get; set; } = true;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoParceria, TipoParceriaDto>();
        }
    }
}
