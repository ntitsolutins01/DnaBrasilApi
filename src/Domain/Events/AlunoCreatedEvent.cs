namespace DnaBrasil.Domain.Events;

public class AlunoCreatedEvent : BaseEvent
{
    public AlunoCreatedEvent(Aluno aluno)
    {
        Aluno = aluno;
    }

    public Aluno Aluno { get; }
}
