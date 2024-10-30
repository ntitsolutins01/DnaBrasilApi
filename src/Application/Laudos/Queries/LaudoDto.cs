using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class LaudoDto
{
    public int Id { get; init; }

    #region Ids

    public int? TalentoEsportivoId { get; init; }
    public int? VocacionalId { get; init; }
    public int? QualidadeDeVidaId { get; init; }
    public int? SaudeId { get; init; }
    public int? ConsumoAlimentarId { get; init; }
    public int? SaudeBucalId { get; init; }
    public int? LocalidadeId { get; init; }
    public int? AlunoId { get; init; }
    public int? EncaminhamentoVocacionalId { get; init; }
    public int? EncaminhamentoConsumoAlimentarId { get; init; }
    public int? EncaminhamentoSaudeBucalId { get; init; }
    public int? EncaminhamentoTalentoEsportivoId { get; init; }

    #endregion

    #region Cabeçalho

    public required string NomeAluno { get; init; }
    public required string NomeLocalidade { get; init; }
    public string? MunicipioEstado { get; init; }
    public string? Sexo { get; init; }
    public string? Etnia { get; init; }
    public string? StatusLaudo { get; init; }
    public DateTime? DtNascimento { get; init; }
    public int? Idade { get; init; }
    public string? Email { get; init; }
    public byte[]? QrCode { get; init; }
    public decimal? Estatura { get; init; }
    public decimal? Massa { get; init; }
    public byte[]? ByteImage { get; init; }
    public string? NomeFoto { get; init; }
    public string? Modalidade { get; init; }
    #endregion

    #region Saude

    public string? ImcSaude { get; init; }

    #endregion

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Laudo, LaudoDto>()
                .ForMember(dest => dest.TalentoEsportivoId, opt => opt.MapFrom(src => src.TalentoEsportivo!.Id))
                .ForMember(dest => dest.VocacionalId, opt => opt.MapFrom(src => src.Vocacional!.Encaminhamento!.Id))
                .ForMember(dest => dest.QualidadeDeVidaId, opt => opt.MapFrom(src => src.QualidadeDeVida!.Id))
                .ForMember(dest => dest.SaudeId, opt => opt.MapFrom(src => src.Saude!.Id))
                .ForMember(dest => dest.ConsumoAlimentarId,
                    opt => opt.MapFrom(src => src.ConsumoAlimentar!.Encaminhamento!.Id))
                .ForMember(dest => dest.SaudeBucalId, opt => opt.MapFrom(src => src.SaudeBucal!.Encaminhamento!.Id))
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => GetSexo(src.Aluno.Sexo)))
                .ForMember(dest => dest.Etnia, opt => opt.MapFrom(src => src.Aluno.Etnia))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => GetIdade(src.Aluno!.DtNascimento, null)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Aluno.Email))
                .ForMember(dest => dest.QrCode, opt => opt.MapFrom(src => src.Aluno.QrCode))
                .ForMember(dest => dest.Estatura, opt => opt.MapFrom(src => src.Saude!.Altura))
                .ForMember(dest => dest.Massa, opt => opt.MapFrom(src => src.Saude!.Massa))
                .ForMember(dest => dest.ByteImage, opt => opt.MapFrom(src => src.Aluno.ByteImage))
                .ForMember(dest => dest.NomeFoto, opt => opt.MapFrom(src => src.Aluno.NomeFoto))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Aluno.Localidade.Id))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Aluno.Localidade.Nome))
                .ForMember(dest => dest.Modalidade, opt => opt.MapFrom(src => src.TalentoEsportivo!.EncaminhamentoTexo))
                .ForMember(dest => dest.EncaminhamentoVocacionalId,
                    opt => opt.MapFrom(src => src.Vocacional!.Encaminhamento!.Id))
                .ForMember(dest => dest.EncaminhamentoConsumoAlimentarId,
                    opt => opt.MapFrom(src => src.ConsumoAlimentar!.Encaminhamento!.Id))
                .ForMember(dest => dest.EncaminhamentoConsumoAlimentarId,
                    opt => opt.MapFrom(src => src.SaudeBucal!.Encaminhamento!.Id))
                .ForMember(dest => dest.EncaminhamentoTalentoEsportivoId,
                    opt => opt.MapFrom(src => src.TalentoEsportivo!.Encaminhamento!.Id))
                .ForMember(dest => dest.ImcSaude,
                    opt => opt.MapFrom(src => GetImc(src.Saude!.Massa, src.Saude!.Altura)))
                .ForMember(dest => dest.MunicipioEstado,
                    opt => opt.MapFrom(src =>
                        src.Aluno.Municipio.Nome!.ToString() + " / " + src.Aluno.Municipio.Estado!.Sigla!.ToString()));
            //.ForMember(dest => dest.DependenciaId, opt => opt.MapFrom(src => src.Dependencia!.Id))
            //.ForMember(dest => dest.Serie, opt => opt.MapFrom(src => src.Dependencia!.Serie))
            //.ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.Dependencia!.Turma));
            //.ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Aluno.Localidade.Id))
            //.ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Aluno.Localidade.Nome))

            //.ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Aluno!.Sexo))
            //.ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.Aluno!.DtNascimento));
        }

        public static string GetImc(decimal? massa, decimal? altura)
        {
            try
            {
                var inteiro = massa! * 100 * 100;
                var dividendo = altura * altura;
                var result = Convert.ToDecimal(inteiro) / Convert.ToDecimal(dividendo);

                Double doublVal = Convert.ToDouble(String.Format("{0:0.00}", result));

                return doublVal.ToString();

            }
            catch
            {
                return 0.ToString();
            }
        }
        public static int GetIdade(DateTime data, DateTime? now = null)
        {
            // Carrega a data do dia para comparação caso data informada seja nula

            now = ((now == null) ? DateTime.Now : now);

            try
            {
                int YearsOld = (now.Value.Year - data.Year);

                if (now.Value.Month < data.Month || (now.Value.Month == data.Month && now.Value.Day < data.Day))
                {
                    YearsOld--;
                }

                return (YearsOld < 0) ? 0 : YearsOld;
            }
            catch
            {
                return 0;
            }
        }
        public static string GetSexo(string sigla)
        {
            return sigla switch
            {
                "F" => "Feminino",
                "M" => "Masculino",
                _ => "Não Definido"
            };
        }
    }
}
