using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class LaudoDto
{
    public int? Id { get; init; }
    public int? TalentoEsportivoId { get; init; }
    public int? VocacionalId { get; init; }
    public int? QualidadeDeVidaId { get; init; }
    public int? SaudeId { get; init; }
    public int? ConsumoAlimentarId { get; init; }
    public int? SaudeBucalId { get; init; }
    public int? AlunoId { get; init; }
    public required string NomeAluno { get; init; }
    public int? LocalidadeId { get; init; }
    public required string NomeLocalidade { get; init; }
    public string? MunicipioEstado { get; init; }
    public string? Sexo { get; init; }
    public string? StatusLaudo { get; init; }
    public DateTime? DtNascimento { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Laudo, LaudoDto>()
                .ForMember(dest => dest.TalentoEsportivoId, opt => opt.MapFrom(src => src.TalentoEsportivo!.Id))
                .ForMember(dest => dest.VocacionalId, opt => opt.MapFrom(src => src.Vocacional!.Id))
                .ForMember(dest => dest.QualidadeDeVidaId, opt => opt.MapFrom(src => src.QualidadeDeVida!.Id))
                .ForMember(dest => dest.SaudeId, opt => opt.MapFrom(src => src.Saude!.Id))
                .ForMember(dest => dest.ConsumoAlimentarId, opt => opt.MapFrom(src => src.ConsumoAlimentar!.Id))
                .ForMember(dest => dest.SaudeBucalId, opt => opt.MapFrom(src => src.SaudeBucal!.Id))
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome));
            //.ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Aluno.Localidade.Id))
            //.ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Aluno.Localidade.Nome))
            //.ForMember(dest => dest.MunicipioEstado,
            //    opt => opt.MapFrom(src =>
            //        src.Aluno.Municipio.Nome!.ToString() + " / " + src.Aluno.Municipio.Estado!.Sigla!.ToString()))
            //.ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Aluno!.Sexo))
            //.ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.Aluno!.DtNascimento));
        }


    }
}
