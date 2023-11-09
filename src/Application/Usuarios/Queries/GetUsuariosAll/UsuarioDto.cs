using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Usuarios.Queries.GetUsuariosAll;
public class UsuarioDto
{
    public int Id { get; init; }
    public required string AspNetUserId { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required string AspNetRoleId { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
