using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class SaudeDto
{
    public int Id { get; init; }
    public int ProfissionalId { get; set; }
    public string? NomeProfissional { get; set; }
    public decimal? Altura { get; set; }
    public decimal? Massa { get; set; }
    public decimal? Envergadura { get; set; }
    public string? DataRealizacaoTeste { get; set; }
    public DateTime DtNascimento { get; set; }
    public string? Sexo { get; set; }
    public string? Imc { get; set; }
    public int AlunoId { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Saude, SaudeDto>()
                .ForMember(dest => dest.ProfissionalId, opt => opt.MapFrom(src => src.Profissional!.Id))
                .ForMember(dest => dest.NomeProfissional, opt => opt.MapFrom(src => src.Profissional!.Nome))
                .ForMember(dest => dest.DataRealizacaoTeste, opt => opt.MapFrom(src => src.Created.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.Aluno!.DtNascimento))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Aluno!.Sexo))
                .ForMember(dest => dest.Imc, opt => opt.MapFrom(src => GetImc(src.Massa, src.Altura)))
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id));
        }

        public static string GetImc(decimal? massa, decimal? altura)
        {
            try
            {
                var inteiro = massa! * 100 * 100;
                var dividendo = altura * altura;
                var result = Convert.ToDecimal(inteiro)  / Convert.ToDecimal(dividendo);

                Double doublVal = Convert.ToDouble(String.Format("{0:0.00}", result));

                return doublVal.ToString();

            }
            catch
            {
                return 0.ToString();
            }
        }
    }
}
