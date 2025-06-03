using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ModulosEad.Queries;

public class ModuloEadDto
{
    public required int Id { get; init; }
    public required string Titulo { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
    public required int CursoId { get; init; }
    public required string TituloCurso { get; init; }
    public int? Ordem { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ModuloEad, ModuloEadDto>()
                .ForMember(dest => dest.CursoId, opt => opt.MapFrom(src => src.Curso.Id))
                .ForMember(dest => dest.TituloCurso, opt => opt.MapFrom(src => src.Curso.Titulo));

        }
    }
}
