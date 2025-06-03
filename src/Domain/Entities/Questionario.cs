namespace DnaBrasilApi.Domain.Entities;
public class Questionario : BaseAuditableEntity
{
    public required string Pergunta { get; set; }
    public required TipoLaudo TipoLaudo { get; set; }
    public List<Resposta>? Respostas { get; set; }
    public required int Quadrante { get; set; }
    public required int Questao { get; set; }

}
