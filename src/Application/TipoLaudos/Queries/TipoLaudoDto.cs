using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TipoLaudos.Queries;

public class TipoLaudoDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoLaudo, TipoLaudoDto>();
        }
    }
}
