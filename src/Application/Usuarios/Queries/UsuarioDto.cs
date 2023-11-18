using DnaBrasilApi.Application.Perfis.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Usuarios.Queries;
public class UsuarioDto
{
    public int Id { get; init; }
    public required string AspNetUserId { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required string Email { get; set; }
    public required string AspNetRoleId { get; set; }
    public PerfilDto? Perfil { get; set; }
    public bool? Status { get; set; } = true;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
