using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunoDto
{
    public int Id { get; set; }
    //public  string? AspNetUserId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Sexo { get; set; }
    public string? DtNascimento { get; set; }
    public string? NomeMae { get; set; }
    public string? NomePai { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Url { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
    public string? Etnia { get; set; }
    public int Idade { get; set; }
    public string? NomeMunicipio { get; set; }
    public string? NomeLocalidade { get; set; }
    public string? MunicipioEstado { get; set; }
    public string? Controle { get; set; }
    public string? Estado { get; set; }
    public string? NomeFoto { get; set; }
    public byte[]? ByteImage { get; set; }
    public byte[]? QrCode { get; set; }
    public string? ModalidadeLinhaAcao { get; set; }
    public string? LinhaAcaoId { get; set; }
    public string? FomentoId { get; set; }
    public string? LocalidadeId { get; set; }
    public string? DeficienciaId { get; set; }
    public string? ProfissionalId { get; set; }
    public string? MunicipioId { get; set; }
    public string? IdLocalidadeId { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(dest => dest.DeficienciaId, opt => opt.MapFrom(src => src.Deficiencia!.Id.ToString()))
                .ForMember(dest => dest.ModalidadeLinhaAcao, opt => opt.MapFrom(src => src.LinhaAcao!.Nome))
                .ForMember(dest => dest.ProfissionalId, opt => opt.MapFrom(src => src.Profissional!.Id.ToString()))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id.ToString()))
                .ForMember(dest => dest.NomeMunicipio, opt => opt.MapFrom(src => src.Municipio!.Nome))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade!.Id.ToString()))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade!.Nome))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => GetIdade(src.DtNascimento, null)))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo == "F" ? "Feminino" : "Masculino"))
                .ForMember(dest => dest.DtNascimento,
                    opt => opt.MapFrom(src => src.DtNascimento.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.MunicipioEstado,
                    opt => opt.MapFrom(src =>
                        src.Municipio!.Nome!.ToString() + " / " + src.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.LinhaAcaoId, opt => opt.MapFrom(src => src.LinhaAcao!.Id.ToString()))
                .ForMember(dest => dest.FomentoId, opt => opt.MapFrom(src => src.Fomento!.Id.ToString()))
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
