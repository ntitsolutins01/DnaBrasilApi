using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunoDto
{
    /// <summary>
    /// Matrícula do aluno - Identificador único
    /// </summary>
    public int Id { get; init; }
    //public  string? AspNetUserId { get; init; }
    public string? Nome { get; init; }
    public string? Email { get; init; }
    public string? Sexo { get; init; }
    public string? DtNascimento { get; init; }
    public string? NomeMae { get; init; }
    public string? NomePai { get; init; }
    public string? Cpf { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Cep { get; init; }
    public string? Endereco { get; init; }
    public string? Numero { get; init; }
    public string? Bairro { get; init; }
    public string? Url { get; init; }
    public bool Status { get; init; }
    public bool Habilitado { get; init; }
    public string? Etnia { get; init; }
    public int Idade { get; init; }
    public string? NomeMunicipio { get; init; }
    public string? NomeLocalidade { get; init; }
    public string? MunicipioEstado { get; init; }
    public string? Controle { get; init; }
    public string? Estado { get; init; }
    public string? NomeFoto { get; init; }
    public byte[]? ByteImage { get; init; }
    public byte[]? QrCode { get; init; }
    public string? ModalidadeLinhaAcao { get; init; }
    public string? LinhaAcaoId { get; init; }
    public string? FomentoId { get; init; }
    public string? LocalidadeId { get; init; }
    public string? DeficienciaId { get; init; }
    public string? ProfissionalId { get; init; }
    public string? MunicipioId { get; init; }
    public string? ModalidadesIds { get; init; }
    public string? Modalidades { get; init; }
    public string? SerieTurma { get; init; }
    public string? SerieId { get; init; }
    public string? EtapaId { get; init; }
    public string? SerieNome { get; init; }
    public List<LaudoOrdemDto>? Laudos { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.ToUpper()))
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
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Municipio.Estado!.Sigla))
                .ForMember(dest => dest.ModalidadesIds,
                    opt => opt.MapFrom(src =>
                        src.AlunoModalidades == null
                            ? ""
                            : string.Join(",",
                                src.AlunoModalidades!.Select(s => s.ModalidadeId.ToString()).ToArray())))
                .ForMember(dest => dest.Modalidades,
                    opt => opt.MapFrom(src =>
                        src.AlunoModalidades == null
                            ? ""
                            : string.Join(", ",
                                src.AlunoModalidades!.Select(s => s.Modalidade!.Nome!.ToString()).ToArray())))
                .ForMember(dest => dest.SerieTurma, opt => opt.MapFrom(src => src.Serie!.Nome + " - " + src.Serie!.Turma))
                .ForMember(dest => dest.SerieId, opt => opt.MapFrom(src => src.Serie!.Id))
                .ForMember(dest => dest.SerieNome, opt => opt.MapFrom(src => src.Serie!.Nome))
                .ForMember(dest => dest.EtapaId, opt => opt.MapFrom(src => src.Serie!.EtapaEnsino.Id));
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
