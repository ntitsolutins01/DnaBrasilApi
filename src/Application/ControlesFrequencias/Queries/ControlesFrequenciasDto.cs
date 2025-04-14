using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequencias.Queries;
public class ControlesFrequenciasDto
{   
    public int Id { get; set; }
    public int? DisciplinaId { get; set; }
    public string? Presenca { get; set; }
    public string? Justificativa { get; set; }
    public string? Data { get; set; }
    public bool Status { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControleFrequencia, ControlesFrequenciasDto>()
                .ForMember(dest => dest.DisciplinaId, opt => opt.MapFrom(src => src.Disciplina!.Id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Created.ToString("dd/MM/yyyy")));
        }
    }
}
