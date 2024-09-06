using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiFuncionalidadesGuard
{
    public static void PossuiFuncionalidades(this IGuardClause guardClause,bool input)
    {
        if (input)
            throw new ArgumentException("Este módulo não pode ser excluído pois possui funcionalidades vinculadas a ele.");
    }
}
