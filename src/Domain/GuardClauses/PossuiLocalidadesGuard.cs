using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiLocalidadesGuard
{
    public static void PossuiLocalidades(this IGuardClause guardClause,bool input)
    {
        if (input)
            throw new ArgumentException("Este fomento não pode ser excluído pois possui localidades vinculadas.");
    }
}
