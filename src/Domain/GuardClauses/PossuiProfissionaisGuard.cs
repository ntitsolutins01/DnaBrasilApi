using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiProfissionaisGuard
{
    public static void PossuiProfissionais(this IGuardClause guardClause,bool input)
    {
        if (input)
            throw new ArgumentException("Esta localidade não pode ser excluída pois possui profissionais vinculados.");
    }
}
