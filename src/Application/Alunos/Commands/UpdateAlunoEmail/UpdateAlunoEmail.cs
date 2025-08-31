using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoEmail;

public record UpdateAlunoEmailCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string? Email { get; set; }
}

public class UpdateAlunoEmailCommandHandler : IRequestHandler<UpdateAlunoEmailCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoEmailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateAlunoEmailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Email = request.Email!;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;//true
    }
}
