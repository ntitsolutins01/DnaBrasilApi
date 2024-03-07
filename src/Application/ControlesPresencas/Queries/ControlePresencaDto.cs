using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries;
public class ControlePresencaDto
{   
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public required string NomeAluno { get; set; }
    public required string Controle { get; set; }
    public string? Justificativa { get; set; }
    public string? MunicipioEstado { get; set; }
    public string? NomeLocalidade { get; set; }
    public string? Data { get; set; }
    public int? LocalidadeId { get; set; }
    public int? MunicipioId { get; set; }
    public bool Status { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControlePresenca, ControlePresencaDto>()
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno!.Nome))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Aluno!.Municipio.Id))
                .ForMember(dest => dest.MunicipioEstado, opt => opt.MapFrom(src => src.Aluno.Municipio!.Nome!.ToString() + " / " + src.Aluno.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Aluno.Localidade!.Id))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Aluno.Localidade!.Nome))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Created.ToString("dd/MM/yyyy")));
        }
    }
}
