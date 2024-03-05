using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateQualidadeVida;

public record CreateQualidadeDeVidaCommand : IRequest<int>
{
    public int ProfissionalId { get; init; }
    public required int AlunoId { get; init; }
    public string[]? ListQualidadeDeVida { get; set; }
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

        var profissional = await _context.Profissionais
            .FindAsync([request.ProfissionalId], cancellationToken);

        Guard.Against.NotFound((int)request.ProfissionalId, profissional);


        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId, aluno);

        foreach (string item in request.ListQualidadeDeVida!)
        {
            var resposta = await _context.Respostas
                .FindAsync([item], cancellationToken);

            Guard.Against.NotFound(item, resposta);

            var entity = new QualidadeDeVida
            {
                Profissional = profissional,
                Aluno = aluno,
                Resposta = resposta
            };

            _context.QualidadeDeVidas.Add(entity);

        }

        await _context.SaveChangesAsync(cancellationToken);

        return 0;
    }
}
