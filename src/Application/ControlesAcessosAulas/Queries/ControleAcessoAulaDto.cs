using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesAcessosAulas.Queries;

public class ControleAcessoAulaDto
{
    public required int Id { get; set; }
    public required Aula Aula { get; set; }
    public bool IdentificacaoAluno { get; set; }
    public bool AulaRequisito { get; set; }
    public bool PermanenciaAula { get; set; }
    public TimeSpan? TempoPermanecia { get; set; }
    public required string LiberacaoAula { get; set; }
    public DateTime? DataLiberacao { get; set; }
    public DateTime DataEncerramento { get; set; }
    public bool Status { get; set; }
 
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControleAcessoAula, ControleAcessoAulaDto>();
        }
    }
}
