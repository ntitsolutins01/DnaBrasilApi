using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class ModalidadeNaoEncontradaGuard
{
    public static void ModalidadeNaoEncontrada(this IGuardClause guardClause, bool input)
    {
        if (input)
            throw new ArgumentException("Modalidade não encontrada.");
    }
}
