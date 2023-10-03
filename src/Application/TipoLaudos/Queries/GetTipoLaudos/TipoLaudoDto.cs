using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudos;

public class TipoLaudoDto
{
    public int Id { get; init; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int IdadeInicial { get; set; }
    public int IdadeFinal { get; set; }
    public int ScoreTotal { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoLaudo, TipoLaudoDto>();
        }
    }
}
