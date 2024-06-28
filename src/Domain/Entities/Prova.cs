using System.Security.AccessControl;

namespace DnaBrasilApi.Domain.Entities;

public class Prova : BaseAuditableEntity
{
    public required Aula Aula { get; set; }
    public required string Titulo  { get; set; }
    public bool ProvaRequisito { get; set; }
    public required int Peso { get; set; } 
    public required int MediaAprovacao { get; set; }
    public required string LiberacaoProva { get; set; }
    public required DateTime DataLiberacao { get; set; }
    public required TimeSpan DuracaoProva { get; set; }
    public DateTime? DataEncerramento { get; set; }
    public bool PermitirTentativas { get; set; } = false;
    public int Tentativas { get; set; }
    public bool LiberarTentativa { get; set; } = false;
    public bool Status { get; set; } = true;
 }
