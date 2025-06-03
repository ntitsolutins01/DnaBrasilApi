using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Aulas.Commands.CreateAula;
public record CreateAulaCommand : IRequest<int>
{
    public required int ProfessorId { get; init; }
    public required int ModuloEadId { get; init; }
    public required string Titulo { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; } = true;
    public string? Material { get; init; }
    public string? NomeMaterial { get; init; }
    public string? Video { get; init; }
    public string? NomeVideo { get; init; }
    public int? Ordem { get; init; }
}

public class CreateAulaCommandHandler : IRequestHandler<CreateAulaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAulaCommand request, CancellationToken cancellationToken)
    {
        var professor = await _context.Usuarios
            .FindAsync([request.ProfessorId], cancellationToken);

        Guard.Against.NotFound(request.ProfessorId, professor);

        var moduloEad = await _context.ModulosEad
            .FindAsync([request.ModuloEadId], cancellationToken);

        Guard.Against.NotFound(request.ModuloEadId, moduloEad);

        var entity = new Aula
        {
            Professor = professor,
            ModuloEad = moduloEad,
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            Status = request.Status,
            Video = request.Video,
            NomeVideo = request.NomeVideo,
            Material = request.Material,
            NomeMaterial = request.NomeMaterial,
            Ordem = request.Ordem
        };

        _context.Aulas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
