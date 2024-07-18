using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiAlunosGuard
{
    public static void PossuiAlunos(this IGuardClause guardClause,bool input)
    {
        if (input)
            throw new ArgumentException("O Prodissional possui alunos vinculados.");
    }
}
