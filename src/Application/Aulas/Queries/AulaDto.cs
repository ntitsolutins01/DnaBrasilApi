using DnaBrasilApi.Application.QuestoesEad.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Aulas.Queries;

public class AulaDto
{
    public required int Id { get; init; }
    public required int ModuloEadId { get; init; }
    public required string NomeProfessor { get; init; }
    public required string NomeCurso { get; set; }
    public required int ProfessorId { get; init; }
    public required string TituloModuloEad { get; init; }
    public required string Titulo { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
    public string? Material { get; init; }
    public string? NomeMaterial { get; init; }
    public string? Video { get; init; }
    public string? NomeVideo { get; init; }
    public int? Ordem { get; init; }
    public IList<QuestaoEadDto>? Questoes { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aula, AulaDto>()
                .ForMember(dest => dest.NomeProfessor, opt => opt.MapFrom(src => src.Professor.Nome))
                .ForMember(dest => dest.ProfessorId, opt => opt.MapFrom(src => src.Professor.Id))
                .ForMember(dest => dest.TituloModuloEad, opt => opt.MapFrom(src => src.ModuloEad.Titulo))
                .ForMember(dest => dest.ModuloEadId, opt => opt.MapFrom(src => src.ModuloEad.Id))
                .ForMember(dest => dest.NomeCurso, opt => opt.MapFrom(src => src.ModuloEad.Curso.Titulo));
        }
    }
}
