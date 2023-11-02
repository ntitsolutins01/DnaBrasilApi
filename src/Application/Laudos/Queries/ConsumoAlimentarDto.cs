using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Queries;
public class ConsumoAlimentarDto
{
    public required Profissional Profissional { get; set; }
    public required Questionario Questionario { get; set; }
    public required string Resposta { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ConsumoAlimentar, ConsumoAlimentarDto>();
        }
    }
}
