namespace DnaBrasilApi.Domain.Entities;
public class FomentoLocalidade 
{
    public int FomentoId { get; set; }
    public int LocalidadeId { get; set; }
    public Fomentu? Fomento { get; set; }
    public Localidade? Localidade { get; set; }
    public bool Status { get; set; } = true;
}
