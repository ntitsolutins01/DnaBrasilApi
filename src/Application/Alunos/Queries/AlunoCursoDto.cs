using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoCursoDto
{
    public required string AlunoId { get; init; }
    public required string CursoId { get; init; }
    public string? CertificadoId { get; init; }
    public int Progresso { get; init; }
    public bool Status { get; init; }
    public string? Matricula { get; init; }
    public string? Idade { get; init; }
    public string? NomeAluno { get; init; }
    public string? LocalidadeMunicipioUf { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoCursoCertificado, AlunoCursoDto>()
                .ForMember(dest => dest.Matricula, opt => opt.MapFrom(src => src.Aluno!.Id))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno!.Nome))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => GetIdade(src.Aluno!.DtNascimento, null)))
                .ForMember(dest => dest.LocalidadeMunicipioUf, opt => opt.MapFrom(src => src.Aluno!.Localidade.Nome + " - " + src.Aluno.Municipio!.Nome!.ToString() + " / " + src.Aluno.Municipio!.Estado!.Sigla!.ToString()));

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
