using DnaBrasilApi.Application.Localidades.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class MatriculaDto
{
    public int Id { get; set; }
    public string? DtVencimentoParq { get; set; }
    public string? DtVencimentoAtestadoMedico { get; set; }
    public string? NomeResponsavel1 { get; set; }
    public string? ParentescoResponsavel1 { get; set; }
    public string? CpfResponsavel1 { get; set; }
    public string? NomeResponsavel2 { get; set; }
    public string? ParentescoResponsavel2 { get; set; }
    public string? CpfResponsavel2 { get; set; }
    public string? NomeResponsavel3 { get; set; }
    public string? ParentescoResponsavel3 { get; set; }
    public string? CpfResponsavel3 { get; set; }
    public LocalidadeDto? Localidade { get; set; }
    public AlunoDto? Aluno { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Matricula, MatriculaDto>()
                .ForMember(dest => dest.DtVencimentoAtestadoMedico, opt => opt.MapFrom(src => src.DtVencimentoAtestadoMedico.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.DtVencimentoParq, opt => opt.MapFrom(src => src.DtVencimentoParq.ToString("dd/MM/yyyy")));
        }
    }
}
