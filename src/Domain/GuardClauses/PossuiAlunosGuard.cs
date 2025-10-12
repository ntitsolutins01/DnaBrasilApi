using Ardalis.GuardClauses;

namespace DnaBrasilApi.Domain.GuardClauses;

public static class PossuiAlunosGuard
{
    public static void PossuiAlunos(this IGuardClause guardClause, bool input)
    {
        if (input)
            throw new ArgumentException("Este profissional não pode ser excluído pois possui alunos vinculados, para excluílo, vincule os alunos deste profissional a um outro profissional cadastrado, clicando em desvincular alunos.");
    }
    public static void PossuiAlunosLocalidades(this IGuardClause guardClause, bool input)
    {
        if (input)
            throw new ArgumentException("Esta localidade não pode ser excluída pois possui alunos vinculados, para excluílo.");
    }
    public static void PossuiAlunosEtapasEnsino(this IGuardClause guardClause, bool input)
    {
        if (input)
            throw new ArgumentException("Esta etapa de ensino não pode ser excluída pois possui alunos vinculados às suas séries.");
    }


}
