using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Commands.CreateVocacional;

public record CreateVocacionalCommand : IRequest<int>
{
    public required Profissional Profissional { get; init; }
    public required Questionario Questionario { get; init; }
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
        var entity = new Vocacional
        {
            Profissional = request.Profissional,
            Questionario = request.Questionario,
            Resposta = request.Resposta
        };

        _context.Vocacionais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
