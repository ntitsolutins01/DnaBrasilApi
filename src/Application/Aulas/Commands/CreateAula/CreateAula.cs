using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Aulas.Commands.CreateAula;
public record CreateAulaCommand : IRequest<int>
{
    public required int CargaHoraria { get; set; }
    public required int ProfessorId { get; set; }
    public required int MuduloEadId { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; init; } = true;
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
            .FindAsync([request.MuduloEadId], cancellationToken);

        Guard.Against.NotFound(request.MuduloEadId, moduloEad);

        var entity = new Aula
        {
            CargaHoraria = request.CargaHoraria,
            Professor = professor,
            ModuloEad = moduloEad,
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            Status = request.Status
        };

        _context.Aulas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
