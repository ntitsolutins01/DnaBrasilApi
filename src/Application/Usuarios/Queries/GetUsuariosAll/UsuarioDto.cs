using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Usuarios.Queries.GetUsuarioAll;
public class UsuarioDto
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
