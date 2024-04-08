using DnaBrasilApi.Application.Deficiencias.Queries;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunoDto
{
    public int Id { get; set; }
    //public  int AspNetUserId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Sexo { get; set; }
    public string? DtNascimento { get; set; }
    //public string? NomeMae { get; set; }
    //public string? NomePai { get; set; }
    public string? Cpf { get; set; }
    //public string? Telefone { get; set; }
    public string? Celular { get; set; }
    //public string? Cep { get; set; }
    //public string? Endereco { get; set; }
    //public string? Numero { get; set; }
    //public string? Bairro { get; set; }
    //public string? RedeSocial { get; set; }
    public string? Url { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
    public string? Etnia { get; set; }
    public int IdCliente { get; set; }
    public int Idade { get; set; }


    //public MunicipioDto? Municipio { get; set; }
    //public LocalidadeDto? Localidade { get; set; }
    //public ParceiroDto? Parceiro { get; set; }
    public List<DeficienciaDto>? Deficiencias { get; set; }
    //public List<AmbienteDto>? Ambientes { get; set; }
    //public List<ContratoDto>? Contratos { get; set; }
    public MatriculaDto? Matricula { get; set; }
    public VoucherDto? Voucher { get; set; }
    //public DependenciaDto? Dependencia { get; set; }
    //public List<LaudoDto>? Laudos { get; set; }

    public int? MunicipioId { get; set; }
    public string? NomeMunicipio { get; set; }
    public int? LocalidadeId { get; set; }
    public int? DependenciaId { get; set; }
    public int? ProfissionalId { get; set; }
    public int? MatriculaId { get; set; }
    public string? NomeLocalidade { get; set; }
    public string? MunicipioEstado { get; set; }
    public string? Controle { get; set; }
    public string? Estado { get; set; }
    public SaudeDto? Saude { get; set; }
    //public TalentoEsportivoDto? TalentoEsportivo { get; set; }
    //public VocacionalDto? Vocacional { get; set; }
    public string? NomeFoto { get; set; }
    public byte[]? ByteImage { get; set; }
    public byte[]? QrCode { get; set; }
    public string? ModalidadeLinhaAcao { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoDto>()
                //.ForMember(dest => dest.Controle, opt => opt.MapFrom(src => src.Dependencia!.Turma))
                //.ForMember(dest => dest.DependenciaId, opt => opt.MapFrom(src => src.Dependencia!.Id))
                .ForMember(dest => dest.MatriculaId, opt => opt.MapFrom(src => src.Matricula!.Id))
                .ForMember(dest => dest.ProfissionalId, opt => opt.MapFrom(src => src.Profissional!.Id))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id))
                .ForMember(dest => dest.NomeMunicipio, opt => opt.MapFrom(src => src.Municipio!.Nome))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade!.Id))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade!.Nome))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => GetIdade(src.DtNascimento,null)))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo == "F" ? "Feminino" : "Masculino"))
                .ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.DtNascimento.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.MunicipioEstado, opt => opt.MapFrom(src => src.Municipio!.Nome!.ToString() + " / " + src.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Municipio.Estado!.Sigla));
        }
    }



    /// <summary>
    /// Calcula quantidade de anos passdos com base em duas datas, caso encontre qualquer problema retorna 0 
    /// </summary>
    /// <param name="data">Data inicial</param>
    /// <param name="now">Data final ou deixar nula para data atual</param>
    /// <returns>Retorna inteiro com quantiadde de anos</returns>
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

}
