using DnaBrasilApi.Application.Localidades.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Categorias.Queries;

public class CategoriaDto
{
    public required int Id { get; init; }
    public required string Codigo { get; init; }
    public required string Nome { get; init; }
    public required int IdadeInicial { get; init; }
    public required int IdadeFinal { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Categoria, CategoriaDto>();
        }
    }
}
