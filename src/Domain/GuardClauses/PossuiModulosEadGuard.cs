using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiModulosEadGuard
{
    public static void PossuiModulosEad(this IGuardClause guardClause, bool input)
    {
        if (input)
            throw new ArgumentException("Este curso não pode ser excluído pois possui módulos vinculadas a ele.");
    }
}
