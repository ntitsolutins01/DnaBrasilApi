using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Notas.Queries;

public class NotaDto
{
    public required int Id { get; set; }
    public required Aluno Aluno { get; set; }
    public required Disciplina Disciplina { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? PrimeiroBimestre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? SegundoBimestre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? TerceiroBimestre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? QuartoBimestre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? Media { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Nota, NotaDto>();
        }
    }
}
