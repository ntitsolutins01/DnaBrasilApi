namespace DnaBrasilApi.Domain.Entities;

public class Prova : BaseAuditableEntity
{
    public required Aula Aula { get; set; }
    public required string Titulo { get; set; }
    public required bool ProvaRequisito { get; set; }
    public required int Peso { get; set; }
    public required int MediaAprovacao { get; set; }
    public required string LiberacaoProva { get; set; }
    public required DateTime DataLiberacao { get; set; }
    public required DateTime DataEncerramento { get; set; }
    public bool Status { get; set; } = true;
 }
