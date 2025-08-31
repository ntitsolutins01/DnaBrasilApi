namespace DnaBrasilApi.Application.QuestoesEad.Commands.CreateQuestaoEad;
public class RespostaEadModel
{
    public int Id { get; set; }
    public required string TipoResposta { get; set; }
    public required string Resposta { get; set; }
    public decimal ValorPesoResposta { get; set; }
    public bool RespostaCerta { get; set; }
}
