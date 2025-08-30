using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateLaudoEducacional;

public record UpdateLaudoEducacionalCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required int AlunoId { get; init; }
    public required int EducacionalId { get; init; }
    public required string Materia { get; init; }
}

public class UpdateLaudoEducacionalCommandHandler : IRequestHandler<UpdateLaudoEducacionalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateLaudoEducacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateLaudoEducacionalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Laudos
            .FindAsync([request.Id], cancellationToken);
        
        Guard.Against.NotFound(request.Id, entity);

        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);
        
        Guard.Against.NotFound(request.AlunoId, aluno);

        if (request.Materia == "MT")
        {
            var educacional = await _context.Educacionais
                .FindAsync([request.EducacionalId], cancellationToken);

            Guard.Against.NotFound(request.EducacionalId, educacional);

            entity.Aluno = aluno;
            entity.EducacionalMatematica = educacional;
        }
        else
        {
            var educacional = await _context.Educacionais
                .FindAsync([request.EducacionalId], cancellationToken);

            Guard.Against.NotFound(request.EducacionalId, educacional);

            entity.Aluno = aluno;
            entity.EducacionalPortugues = educacional;
        }

        await _context.SaveChangesAsync(cancellationToken); var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }
}
