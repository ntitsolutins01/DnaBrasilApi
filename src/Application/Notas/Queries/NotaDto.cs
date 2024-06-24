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
    public string? LocalidadeMunicipioUf { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Nota, NotaDto>()
                .ForMember(dest => dest.LocalidadeMunicipioUf, opt => opt.MapFrom(src => src.Aluno.Localidade.Nome + " - " +src.Aluno.Municipio!.Nome!.ToString() + " / " + src.Aluno.Municipio!.Estado!.Sigla!.ToString()));
        }
    }
}
