using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class AlunoExisteGuard
{
    public static void AlunoExiste(this IGuardClause guardClause, bool input)
    {
        if (input)
            throw new ArgumentException("Este cpf ou email já pertencem a outro aluno.");
    }
}
