using System.Security.AccessControl;

namespace DnaBrasilApi.Domain.Entities;

public class ControleAcessoAula : BaseAuditableEntity
{
   public required Aula Aula { get; set; }
   public bool IdentificacaoAluno { get; set; } = false;
   public bool AulaRequisito { get; set; } = false;
   public bool PermanenciaAula { get; set; } = false;
   public TimeSpan? TempoPermanecia { get; set; }
   public required string LiberacaoAula { get; set; }
   public DateTime? DataLiberacao { get; set; }
   public DateTime DataEncerramento { get; set; }
   public bool Status { get; set; } = true;
}
