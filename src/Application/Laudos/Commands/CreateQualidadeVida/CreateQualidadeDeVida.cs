using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateQualidadeVida;

public record CreateQualidadeDeVidaCommand : IRequest<int>
{
    public int ProfissionalId { get; init; }
    public int AlunoId { get; init; }
    public required string Resposta { get; init; }
}

public class CreateQualidadeDeVidaCommandHandler : IRequestHandler<CreateQualidadeDeVidaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateQualidadeDeVidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateQualidadeDeVidaCommand request, CancellationToken cancellationToken)
    {

        var aluno = await _context.Alunos.FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound((int)request.ProfissionalId, profissional);

        var entity = new QualidadeDeVida
        {
            Profissional = profissional,
            Aluno = aluno,
            Resposta = request.Resposta
        };

        _context.QualidadeDeVidas.Add(entity);


        await _context.SaveChangesAsync(cancellationToken);

        return 0;
    }
}
