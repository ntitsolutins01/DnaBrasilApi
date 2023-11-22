using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Series.Queries;
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
