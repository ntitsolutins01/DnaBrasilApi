using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModulosEad.Commands.UpdateModuloEad;

public record UpdateModuloEadCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; init; }
    public int? Ordem { get; set; }
}

public class UpdateModuloEadCommandHandler : IRequestHandler<UpdateModuloEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateModuloEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateModuloEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ModulosEad
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);


        entity.Titulo = request.Titulo;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;
        entity.Ordem = request.Ordem;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
