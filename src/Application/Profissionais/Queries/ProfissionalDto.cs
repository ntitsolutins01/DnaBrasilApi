using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Queries;
public class ProfissionalDto
{
    public int Id { get; set; }
    public string? AspNetUserId { get; set; }
    public string? AspNetRoleId { get; set; }
    public required string Nome { get; set; }
    public string? DtNascimento { get; set; }
    public required string Email { get; set; }
    public string? Sexo { get; set; }
    public required string CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Endereco { get; set; }
    public int? Numero { get; set; }
    public string? Cep { get; set; }
    public string? Bairro { get; set; }
    public bool Status { get; set; } = true;
    public bool Habilitado { get; set; }
    public int EstadoId { get; set; }
    public string? Uf { get; set; }
    public int? MunicipioId { get; set; }
    public int? LocalidadeId { get; set; }
    public string? Perfil { get; set; }
    public string? Localidade { get; set; }
    public string? Cargo { get; set; }
    public string? ModalidadesIds { get; set; }
    public bool? PossuiAlunosVinculados { get; set; }
    public int? QuantidadeAlunosVinculados { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Profissional, ProfissionalDto>()
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id))
                .ForMember(dest => dest.AspNetRoleId, opt => opt.MapFrom(src => src.Perfil!.AspNetRoleId))
                .ForMember(dest => dest.Perfil, opt => opt.MapFrom(src => src.Perfil!.Nome))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade!.Id))
                .ForMember(dest => dest.Localidade, opt => opt.MapFrom(src => src.Localidade!.Nome))
                .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.Municipio!.Estado!.Id))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Municipio!.Estado!.Sigla))
                .ForMember(dest => dest.DtNascimento,
                    opt => opt.MapFrom(src => src.DtNascimento!.Value.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.ModalidadesIds,
                    opt => opt.MapFrom(src =>
                        src.ProfissionalModalidades == null
                            ? ""
                            : string.Join(",",
                                src.ProfissionalModalidades!.Select(s => s.ModalidadeId.ToString()).ToArray())))

            .ForMember(dest => dest.PossuiAlunosVinculados, opt => opt.MapFrom(src => src.Alunos!.Count > 0 ? true : false))
            .ForMember(dest => dest.QuantidadeAlunosVinculados, opt => opt.MapFrom(src => src.Alunos!.Count));
        }
    }
}
