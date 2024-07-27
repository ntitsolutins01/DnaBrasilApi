using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Escolaridades.Commands.CreateEscolaridade;

public record CreateEscolaridadeCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public bool Status { get; init; }
    public required List<Aluno> Alunos { get; init; }
    public required List<Profissional> Profissionais { get; init; }
}

public class CreateEscolaridadeCommandHandler : IRequestHandler<CreateEscolaridadeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEscolaridadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEscolaridadeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Escolaridade
        {
            Nome = request.Nome,
            Status = request.Status

        };

        _context.Escolaridades.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
