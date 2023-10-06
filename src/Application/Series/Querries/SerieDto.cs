using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Series.Querries;
public class SerieDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieDto>();
        }
    }
}
