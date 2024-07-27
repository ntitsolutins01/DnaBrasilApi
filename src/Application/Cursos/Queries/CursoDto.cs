using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Cursos.Queries;

public class CursoDto
{
    public required int Id { get; set; }
    public required int TipoCursoId { get; set; }
    public required string TituloTipoCurso { get; set; }
    public required int UsuarioId { get; set; }
    public required string NomeProfissional { get; set; }
    public required string Titulo { get; set; }
    public required int CargaHoraria { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; }

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
