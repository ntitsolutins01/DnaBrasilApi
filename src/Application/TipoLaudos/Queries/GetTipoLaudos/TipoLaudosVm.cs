namespace DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudos;

public class TipoLaudosVm
{
    public IReadOnlyCollection<TipoLaudoDto> Lists { get; init; } = Array.Empty<TipoLaudoDto>();
}
