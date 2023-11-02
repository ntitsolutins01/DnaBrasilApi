namespace DnaBrasil.Application.TipoLaudos.Queries;

public class TipoLaudosVm
{
    public IReadOnlyCollection<TipoLaudoDto> Lists { get; init; } = Array.Empty<TipoLaudoDto>();
}
