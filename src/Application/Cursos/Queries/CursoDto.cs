using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Cursos.Queries;

public class CursoDto
{
    public required int Id { get; init; }
    public required int TipoCursoId { get; init; }
    public required string TituloTipoCurso { get; init; }
    public required int UsuarioId { get; init; }
    public required string NomeProfissional { get; init; }
    public required string Titulo { get; init; }
    public required int CargaHoraria { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Curso, CursoDto>()
                .ForMember(dest => dest.TipoCursoId, opt => opt.MapFrom(src => src.TipoCurso.Id))
                .ForMember(dest => dest.TituloTipoCurso, opt => opt.MapFrom(src => src.TipoCurso.Nome))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.Usuario.Id))
                .ForMember(dest => dest.NomeProfissional, opt => opt.MapFrom(src => src.Usuario.Nome));
        }
    }
}
