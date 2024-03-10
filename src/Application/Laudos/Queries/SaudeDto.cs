using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class SaudeDto
{
    public int Id { get; init; }
    public int ProfissionalId { get; set; }
    public string? NomeProfissional { get; set; }
    public int? Altura { get; set; }
    public int Massa { get; set; }
    public int? Envergadura { get; set; }
    public string? DataRealizacaoTeste { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Saude, SaudeDto>()
                .ForMember(dest => dest.ProfissionalId, opt => opt.MapFrom(src => src.Profissional!.Id))
                .ForMember(dest => dest.NomeProfissional, opt => opt.MapFrom(src => src.Profissional!.Nome))
                .ForMember(dest => dest.DataRealizacaoTeste, opt => opt.MapFrom(src => src.Created.ToString("dd/MM/yyyy")));
        }
    }
}
