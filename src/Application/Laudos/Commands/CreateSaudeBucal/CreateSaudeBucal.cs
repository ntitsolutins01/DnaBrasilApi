using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateSaudeBucal;

public record CreateSaudeBucalCommand : IRequest<int>
{
    public required Profissional Profissional { get; init; }
    public required Questionario Questionario { get; init; }
    public required string Resposta { get; init; }
}

public class CreateSaudeBucalCommandHandler : IRequestHandler<CreateSaudeBucalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        var entity = new SaudeBucal
        {
            Profissional = request.Profissional,
            Questionario = request.Questionario,
            Resposta = request.Resposta
        };

        _context.SaudeBucais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
