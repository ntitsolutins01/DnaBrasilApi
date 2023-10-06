using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudos;

public class TipoLaudoDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public int IdadeInicial { get; init; }
    public int IdadeFinal { get; init; }
    public int ScoreTotal { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoLaudo, TipoLaudoDto>();
        }
    }
}
