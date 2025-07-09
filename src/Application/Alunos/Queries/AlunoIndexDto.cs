using DnaBrasilApi.Application.DocumentosAluno.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunoIndexDto
{
    public int Id { get; init; }
    public string? AspNetUserId { get; init; }
    public string? Nome { get; init; }
    public string? NomeAluno { get; init; }
    public string? Email { get; init; }
    public string? DtNascimento { get; init; }
    public string? MunicipioId { get; init; }
    public string? MunicipioEstado { get; set; }
    public bool Status { get; init; }
    public bool Convidado { get; init; }
    public bool PossuiLaudoFinalizado { get; init; }
    public string? Modalidades { get; init; }
    public string? NomeLocalidade { get; init; }
    public string? SerieTurma { get; init; }
    public List<DocumentoAlunoDto>? Documentos { get; set; }
    public bool Habilitado { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoIndexDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Id + " - " + src.Nome.ToUpper()))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Nome.ToUpper()))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio.Id))
                .ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.DtNascimento.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.PossuiLaudoFinalizado, opt => 
                    opt.MapFrom(src => src.Laudos!.Any(s => s.StatusLaudo != "A") || src.Laudos!.Count == 0))
                .ForMember(dest => dest.Modalidades,
                    opt => opt.MapFrom(src =>
                        src.AlunoModalidades == null
                            ? ""
                            : string.Join(", ",
                                src.AlunoModalidades!.Select(s => s.Modalidade!.Nome!.ToString()).ToArray())))
                .ForMember(dest => dest.MunicipioEstado,
                    opt => opt.MapFrom(src =>
                        src.Municipio!.Nome!.ToString() + " / " + src.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.SerieTurma,
                    opt => opt.MapFrom(src =>
                        src.Serie!.Nome.ToString() + "  " + src.Serie!.Turma))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade!.Nome));
        }
    }
}
