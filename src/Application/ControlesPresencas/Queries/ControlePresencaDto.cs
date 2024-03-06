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
    public bool Status { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControlePresenca, ControlePresencaDto>()
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno!.Nome));
        }
    }
}
