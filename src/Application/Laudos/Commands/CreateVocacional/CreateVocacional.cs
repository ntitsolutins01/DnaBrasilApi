using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;

public record CreateVocacionalCommand : IRequest<int>
{
    public int ProfissionalId { get; init; }
    public int AlunoId { get; init; }
    public required string Resposta { get; init; }
}

public class CreateVocacionalCommandHandler : IRequestHandler<CreateVocacionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateVocacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateVocacionalCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos.FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound((int)request.ProfissionalId, profissional);

        var entity = new Vocacional
        {
            Profissional = profissional,
            Aluno = aluno,
            Resposta = request.Resposta
        };

        _context.Vocacionais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
