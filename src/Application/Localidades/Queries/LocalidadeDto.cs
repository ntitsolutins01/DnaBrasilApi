using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Localidades.Queries;
public class LocalidadeDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public Municipio? Municipio { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Localidade, LocalidadeDto>();
        }
    }
}
