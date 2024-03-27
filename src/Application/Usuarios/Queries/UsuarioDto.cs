using DnaBrasilApi.Application.Perfis.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Usuarios.Queries;
public class UsuarioDto
{
    public int Id { get; set; }
    public string? AspNetUserId { get; set; }
    public string? Nome { get; set; }
    public string? CpfCnpj { get; set; }
    public string? TipoPessoa { get; set; }
    public string? Email { get; set; }
    public string? AspNetRoleId { get; set; }
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
