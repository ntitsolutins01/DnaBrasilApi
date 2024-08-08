using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Aulas.Queries;

public class AulaDto
{
    public required int Id { get; set; }
    public required int CargaHoraria { get; set; }
    public required string NomeProfessor { get; set; }
    public required int ModuloEadId { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aula, AulaDto>()
                .ForMember(dest => dest.NomeProfessor, opt => opt.MapFrom(src => src.Professor.Nome));
        }
    }
}
