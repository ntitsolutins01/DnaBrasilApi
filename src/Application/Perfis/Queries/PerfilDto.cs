using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Perfis.Queries;
public class PerfilDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Perfil, PerfilDto>();
        }
    }
}
