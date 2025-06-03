using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ArquivosInventarios.Queries;

public class ArquivosInventarioDto
{
    public required int Id { get; init; }
    public required int InventarioId { get; init; }
    public string? PathArquivo { get; init; }
    public string? NomeArquivo { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ArquivosInventario, ArquivosInventarioDto>();
        }
    }
}
