using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Series.Querries;
public class SeriesDto
{
    public int Id { get; init; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SeriesDto>();
        }
    }
}
