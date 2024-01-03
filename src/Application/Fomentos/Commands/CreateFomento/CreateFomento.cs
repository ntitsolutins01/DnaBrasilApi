using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomentos.Commands.CreateFomento;
public record CreateFomentoCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required int MunicipioId { get; init; }
    public required int LocalidadeId { get; init; }
    public required string Codigo { get; set; }
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
        
           var municipio = await _context.Municipios
                .FindAsync(new object[] { request.MunicipioId }, cancellationToken);
           var localidade = await _context.Localidades
                .FindAsync(new object[] { request.LocalidadeId }, cancellationToken);

        var entity = new Fomentu
        {
            Codigo = request.Codigo,
            Nome = request.Nome,
            Municipio = municipio,
            Localidade = localidade!
        };

        _context.Fomentos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
