namespace DnaBrasilApi.Domain.Entities;
public class Resposta : BaseAuditableEntity
{
    public required string RespostaQuestionario { get; set;}
    public required Questionario Questionario { get; set; }
    public required decimal ValorPesoResposta { get; set; }

}
