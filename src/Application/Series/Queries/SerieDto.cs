using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Series.Queries;
public class SerieDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public  int IdadeInicial { get; set; }
    public  int IdadeFinal { get; set; }
    public  int ScoreTotal { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Serie, SerieDto>();
        }
    }
}
