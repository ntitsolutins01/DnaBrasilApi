using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetDesempenhoByAluno;
using DnaBrasilApi.Application.TalentosEsportivos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class LaudoResumidoDto
{
    public int Id { get; set; }
    public string? StatusLaudo { get; set; }
    public int? ModalidadeId { get; set; }
    public int? AlunoId { get; set; }
    public int? SaudeId { get; set; }
    public string? ImcSaude { get; set; }
    public int SaudeBucalId { get; set; }
    public EncaminhamentoDto? EncaminhamentoSaudeBucal { get; set; }
    public int? ConsumoAlimentarId { get; set; }
    public EncaminhamentoDto? EncaminhamentoConsumoAlimentar { get; set; }
    public int? VocacionalId { get; set; }
    public EncaminhamentoDto? EncaminhamentoVocacional { get; set; }
    public int? QualidadeDeVidaId { get; set; }
    public List<EncaminhamentoDto>? EncaminhamentoQualidadeDeVida { get; set; }
    public int? TalentoEsportivoId { get; set; }
    public TalentoEsportivoDto? TalentoEsportivo { get; set; }

    #region RenderHeaderAsync
    public required string NomeModalidade { get; set; }
    public required byte[] ByteImageModalidade { get; set; }
    #endregion

    #region RenderStudentInfoAsync
    public byte[]? ByteImageFotoAluno { get; set; }
    public required string NomeAluno { get; set; }
    public required string NomeLocalidade { get; set; }
    public required string Email { get; set; }
    public required int Idade { get; set; }
    public required string Etnia { get; set; }
    public required string NomeDeficiencia { get; set; }
    public required string DtNascimento { get; set; }
    #endregion

    #region RenderDnaScoreAsync
    public required DesempenhoDto Desempenho { get; set; }
    #endregion


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Laudo, LaudoResumidoDto>()
                .ForMember(dest => dest.NomeModalidade, opt => opt.MapFrom(src => src.Modalidade!.Nome))
                .ForMember(dest => dest.ByteImageModalidade, opt => opt.MapFrom(src => src.Modalidade!.ByteImage))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Aluno.Localidade.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Aluno.Email))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => GetIdade(src.Aluno!.DtNascimento, null)))
                .ForMember(dest => dest.Etnia, opt => opt.MapFrom(src => src.Aluno.Etnia))
                .ForMember(dest => dest.NomeDeficiencia, opt => opt.MapFrom(src => src.Aluno.Deficiencia!.Nome))
                .ForMember(dest => dest.DtNascimento,
                    opt => opt.MapFrom(src => src.Aluno.DtNascimento.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.ImcSaude, opt => opt.MapFrom(src => src.TalentoEsportivo!.Imc))
                .ForMember(dest => dest.EncaminhamentoSaudeBucal,
                    opt => opt.MapFrom(src => src.SaudeBucal!.Encaminhamento))
                .ForMember(dest => dest.EncaminhamentoConsumoAlimentar,
                    opt => opt.MapFrom(src => src.ConsumoAlimentar!.Encaminhamento))
                .ForMember(dest => dest.EncaminhamentoVocacional,
                opt => opt.MapFrom(src => src.Vocacional!.Encaminhamento));
            //.ForMember(dest => dest.StatusLaudo, opt => opt.MapFrom(src => src.StatusLaudo))
            //.ForMember(dest => dest.ModalidadeId, opt => opt.MapFrom(src => src.Modalidade!.Id))
            //.ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id));
            //.ForMember(dest => dest.SaudeId, opt => opt.MapFrom(src => src.Saude!.Id))
            //.ForMember(dest => dest.VocacionalId, opt => opt.MapFrom(src => src.Vocacional!.Id))
            //.ForMember(dest => dest.EncaminhamentoVocacionalId,
            //    opt => opt.MapFrom(src => src.Vocacional!.Encaminhamento!.Id))
            //.ForMember(dest => dest.QualidadeDeVidaId, opt => opt.MapFrom(src => src.QualidadeDeVida!.Id))
            //.ForMember(dest => dest.TalentoEsportivoId, opt => opt.MapFrom(src => src.TalentoEsportivo!.Id))
            //.ForMember(dest => dest.TalentoEsportivo, opt => opt.MapFrom(src => src.TalentoEsportivo));



        }

        //public static DesempenhoDto GetScoreDna(int alunoId)
        //{
        //    try
        //    {
        //        var desempenho = new GetDesempenhoByAlunoQuery(alunoId);
        //        return desempenho.;
        //    }
        //    catch
        //    {
        //        return new DesempenhoDto();
        //    }
        //}

        public static string GetImc(decimal? massa, decimal? altura)
        {
            try
            {
                var inteiro = massa! * 100;
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
