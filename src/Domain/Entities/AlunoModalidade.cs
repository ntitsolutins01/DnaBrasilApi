namespace DnaBrasilApi.Domain.Entities;
public class AlunoModalidade
{
    public int AlunoId { get; set; }
    public int ModalidadeId { get; set; }
    public Aluno? Aluno { get; set; }
    public Modalidade? Modalidade { get; set; }
}
