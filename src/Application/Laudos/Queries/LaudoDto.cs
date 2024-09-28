using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class LaudoDto
{
    public int? Id { get; init; }

    #region Ids

    //public int? DependenciaId { get; init; }
    public int? TalentoEsportivoId { get; init; }
    public int? VocacionalId { get; init; }
    public int? QualidadeDeVidaId { get; init; }
    public int? SaudeId { get; init; }
    public int? ConsumoAlimentarId { get; init; }
    public int? SaudeBucalId { get; init; }
    public int? LocalidadeId { get; init; }
    public int? AlunoId { get; init; }

    #endregion

    #region Cabeçalho

    public required string NomeAluno { get; init; }
    public required string NomeLocalidade { get; init; }
    public string? MunicipioEstado { get; init; }
    public string? Sexo { get; init; }
    public string? StatusLaudo { get; init; }
    public DateTime? DtNascimento { get; init; }
    public string? Email { get; init; }
    public byte[]? QrCode { get; init; }
    public decimal? Estatura { get; init; }
    public decimal? Massa { get; init; }
    public byte[]? ByteImage { get; init; }
    public string? NomeFoto { get; init; }
    public string? Modalidade { get; init; }
    //public string? Serie { get; init; }
    //public string? Turma { get; init; }
    //public int? MunicipioId { get; init; }
    //public string? NomeMunicipio { get; init; }

    #endregion

    #region Vocacional

    

    #endregion

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
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Aluno.Email))
                .ForMember(dest => dest.QrCode, opt => opt.MapFrom(src => src.Aluno.QrCode))
                .ForMember(dest => dest.Estatura, opt => opt.MapFrom(src => src.Saude!.Altura))
                .ForMember(dest => dest.Massa, opt => opt.MapFrom(src => src.Saude!.Massa))
                .ForMember(dest => dest.ByteImage, opt => opt.MapFrom(src => src.Aluno.ByteImage))
                .ForMember(dest => dest.NomeFoto, opt => opt.MapFrom(src => src.Aluno.NomeFoto))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Aluno.Localidade.Id))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Aluno.Localidade.Nome))
                .ForMember(dest => dest.Modalidade, opt => opt.MapFrom(src => src.TalentoEsportivo!.EncaminhamentoTexo));
            //.ForMember(dest => dest.DependenciaId, opt => opt.MapFrom(src => src.Dependencia!.Id))
            //.ForMember(dest => dest.Serie, opt => opt.MapFrom(src => src.Dependencia!.Serie))
            //.ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.Dependencia!.Turma));
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
