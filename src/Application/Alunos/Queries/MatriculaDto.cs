using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Queries;
public class MatriculaDto
{
    public int Id { get; set; }
    public DateTime DtVencimentoParq { get; set; }
    public DateTime DtVencimentoAtestadoMedico { get; set; }
    public string? NomeResponsavel1 { get; set; }
    public string? ParentescoResponsavel1 { get; set; }
    public string? CpfResponsavel1 { get; set; }
    public string? NomeResponsavel2 { get; set; }
    public string? ParentescoResponsavel2 { get; set; }
    public string? CpfResponsavel2 { get; set; }
    public string? NomeResponsavel3 { get; set; }
    public string? ParentescoResponsavel3 { get; set; }
    public string? CpfResponsavel3 { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Matricula, MatriculaDto>();
        }
    }
}
