namespace DnaBrasilApi.Domain.Entities;
public class FomentoLinhaAcao 
{
    public int FomentoId { get; set; }
    public int LinhaAcaoId { get; set; }
    public Fomentu? Fomento { get; set; }
    public LinhaAcao? LinhaAcao { get; set; }
    public bool Status { get; set; } = true;
}
