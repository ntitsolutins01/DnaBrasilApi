namespace DnaBrasilApi.Domain.Entities;

public class AlunoCertificado
{
    public int AlunoId { get; set; }
    public int CertificadoId { get; set; }
    public Aluno? Aluno { get; set; }
    public Certificado? Certificado { get; set; }
}
