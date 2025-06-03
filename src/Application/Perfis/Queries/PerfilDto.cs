using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Perfis.Queries;
public class PerfilDto
{
    public required string Id { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; init; }
    public required string AspNetRoleId { get; set; }
    public bool Status { get; set; } = true;
    public bool Ead { get; set; } = false;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Perfil, PerfilDto>();
        }
    }
}
