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
    public int PerfilId { get; set; }
    public PerfilDto? Perfil { get; set; }
    public bool? Status { get; set; } = true;
    public string? MunicipioEstado { get; init; }
    public string? MunicipioId { get; init; }
    public string? Uf { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Perfil.Id.ToString()))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id.ToString()))
                .ForMember(dest => dest.MunicipioEstado, opt => opt.MapFrom(src => src.Municipio!.Nome!.ToString() + " / " + src.Municipio!.Estado!.Sigla!.ToString()));
        }
    }
}
