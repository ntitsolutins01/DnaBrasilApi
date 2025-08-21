using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiLaudosGuard
{
    public static void PossuiLaudos(this IGuardClause guardClause, bool input)
    {
        if (input)
            throw new ArgumentException("Este aluno não pode ser excluído pois possui laudos vinculados a ele.");
    }
}
