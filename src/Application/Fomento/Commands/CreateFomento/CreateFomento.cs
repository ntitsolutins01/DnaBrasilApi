using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Fomento.Commands.CreateFomento;
public record CreateFomentoCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required int MunicipioId { get; init; }
    public required int LocalidadeId { get; init; }
}

public class CreateFomentoCommandHandler : IRequestHandler<CreateFomentoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFomentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFomentoCommand request, CancellationToken cancellationToken)
    {
        var entity = new Fomentos
        {
            Nome = request.Nome,
            Municipo = municipio,
            Localidade = localidade
        };

        _context.Fomentos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
