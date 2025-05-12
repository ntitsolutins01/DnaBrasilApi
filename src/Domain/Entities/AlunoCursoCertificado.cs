namespace DnaBrasilApi.Domain.Entities;

public class AlunoCursoCertificado
{
    public int AlunoId { get; set; }
    public int CursoId { get; set; }
    public int? CertificadoId { get; set; }
    public Aluno? Aluno { get; set; }
    public Curso? Curso { get; set; }
    public Certificado? Certificado { get; set; }
    public int Progresso { get; set; }
    public bool Status { get; set; } = true;
}
