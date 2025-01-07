using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiLinhasAcoesGuard
{
    public static void PossuiLinhasAcoes(this IGuardClause guardClause,bool input)
    {
        if (input)
            throw new ArgumentException("Este fomento não pode ser excluído pois possui linhas de ações vinculadas.");
    }
}
