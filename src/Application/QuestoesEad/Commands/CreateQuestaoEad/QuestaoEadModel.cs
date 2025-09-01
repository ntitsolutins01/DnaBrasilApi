namespace DnaBrasilApi.Application.QuestoesEad.Commands.CreateQuestaoEad;
public class QuestaoEadModel
{
    public int Id { get; set; }
    public int AulaId { get; set; }
    public string? Referencia { get; set; }
    public required string Enunciado { get; set; }
    public List<RespostaEadModel>? Respostas { get; set; }
    public required int NumeroQuestao { get; set; }
    public List<Dictionary<int, string>>? ListTextos { get; set; }
    public List<Dictionary<int, string>>? ListImagens { get; set; }
}
