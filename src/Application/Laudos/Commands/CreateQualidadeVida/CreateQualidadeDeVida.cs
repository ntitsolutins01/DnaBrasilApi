using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateQualidadeDeVida;

public record CreateQualidadeDeVidaCommand : IRequest<int>
{
    public required Profissional Profissional { get; init; }
    public required Questionario Questionario { get; init; }
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
        var entity = new QualidadeDeVida
        {
            Profissional = request.Profissional,
            Questionario = request.Questionario,
            Resposta = request.Resposta
        };

        _context.QualidadeDeVidas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
