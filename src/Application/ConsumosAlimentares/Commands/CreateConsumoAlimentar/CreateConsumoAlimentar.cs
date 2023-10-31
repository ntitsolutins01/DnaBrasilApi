using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.ConsumosAlimentares.Commands.CreateConsumoAlimentar;

public record CreateConsumoAlimentarCommand : IRequest<int>
{
    public required Profissional Profissional { get; set; }
    public required List<Questionario> Questionarios { get; set; }
    public required string Resposta { get; set; }
    public required Aluno Aluno { get; set; }
}

public class CreateConsumoAlimentarCommandHandler : IRequestHandler<CreateConsumoAlimentarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var entity = new ConsumoAlimentar
        {
            Profissional = request.Profissional,
            Questionarios = request.Questionarios,
            Resposta = request.Resposta,
            Aluno = request.Aluno
        };

        _context.ConsumoAlimentares.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
