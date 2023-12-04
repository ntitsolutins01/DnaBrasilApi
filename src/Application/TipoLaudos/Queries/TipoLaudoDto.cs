using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TipoLaudos.Queries;

public class TipoLaudoDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoLaudo, TipoLaudoDto>();
        }
    }
}
