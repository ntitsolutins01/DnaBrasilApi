using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiAlunosGuard
{
    public static void PossuiAlunos(this IGuardClause guardClause,bool input)
    {
        if (input)
            throw new ArgumentException("Este profissional não pode ser excluído pois possui alunos vinculados.");
    }
}
