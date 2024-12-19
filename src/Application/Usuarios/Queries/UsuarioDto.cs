using DnaBrasilApi.Application.Perfis.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Usuarios.Queries;
public class UsuarioDto
{
    public int Id { get; init; }
    public string? AspNetUserId { get; init; }
    public string? Nome { get; init; }
    public string? CpfCnpj { get; init; }
    public string? TipoPessoa { get; init; }
    public string? Email { get; init; }
    public string? AspNetRoleId { get; init; }
    public PerfilDto? Perfil { get; init; }
    public bool? Status { get; init; } = true;
    public string? MunicipioEstado { get; init; }
    public string? MunicipioId { get; init; }
    public string? Uf { get; init; }
    public string? LocalidadeId { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade!.Id.ToString()))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id.ToString()))
                .ForMember(dest => dest.MunicipioEstado, opt => opt.MapFrom(src => src.Municipio!.Nome!.ToString() + " / " + src.Municipio!.Estado!.Sigla!.ToString()));
        }
    }
}
