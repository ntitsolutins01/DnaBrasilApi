using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiAulasGuard
{
    public static void PossuiAulas(this IGuardClause guardClause, bool input)
    {
        if (input)
            throw new ArgumentException("Este módulo não pode ser excluído pois possui aulas vinculadas a ele.");
    }
}
