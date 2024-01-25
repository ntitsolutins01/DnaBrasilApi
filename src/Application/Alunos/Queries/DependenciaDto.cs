using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class DependenciaDto
{
    public int Id { get; set; }
    public string? Doencas { get; set; }
    public string? Nacionalidade { get; set; }
    public string? Naturalidade { get; set; }
    public string? NomeEscola { get; set; }
    public string? TipoEscola { get; set; }
    public string? TipoEscolaridade { get; set; }
    public string? Turno { get; set; }
    public string? Serie { get; set; }
    public string? Ano { get; set; }
    public string? Turma { get; set; }
    public bool? TermoCompromisso { get; set; }
    public bool? AutorizacaoUsoImagemAudio { get; set; }
    public bool? AutorizacaoUsoIndicadores { get; set; }
    public bool? AutorizacaoSaida { get; set; } = false;
    public required AlunoDto Aluno { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DependenciaOld, DependenciaDto>();
        }
    }
}
