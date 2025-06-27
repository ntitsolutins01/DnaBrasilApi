using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Aulas.Commands.UpdateAula;

public record UpdateAulaCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required int ProfessorId { get; init; }
    public required string Titulo { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
    public string? Material { get; init; }
    public string? NomeMaterial { get; init; }
    public string? Video { get; init; }
    public string? NomeVideo { get; init; }
    public int? Ordem { get; init; }
}

public class UpdateAulaCommandHandler : IRequestHandler<UpdateAulaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateAulaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Aulas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var professor = await _context.Usuarios
            .FindAsync([request.ProfessorId], cancellationToken);

        Guard.Against.NotFound(request.ProfessorId, professor);

        entity.Titulo = request.Titulo;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;
        entity.Professor = professor;
        entity.Material = request.Material;
        entity.NomeMaterial = request.NomeMaterial;
        entity.Video = request.Video;
        entity.NomeVideo = request.NomeVideo;
        entity.Ordem = request.Ordem;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
