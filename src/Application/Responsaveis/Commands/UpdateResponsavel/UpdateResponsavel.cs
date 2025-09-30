using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Responsaveis.Commands.UpdateResponsavel;

public record UpdateResponsavelCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
    public required string Cpf { get; init; }
    public required string Telefone { get; init; }
    public string? Email { get; init; }
    public required int GrauParentescoId { get; init; }
    public bool Status { get; init; }
}

public class UpdateResponsavelCommandHandler : IRequestHandler<UpdateResponsavelCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateResponsavelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateResponsavelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Responsaveis
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var grauParentesco = await _context.GrauParentescos.FindAsync([request.GrauParentescoId], cancellationToken);

        Guard.Against.NotFound((int)request.GrauParentescoId!, grauParentesco);

        entity.Nome = request.Nome;
        entity.Cpf = request.Cpf;
        entity.Telefone = request.Telefone;
        entity.Email = request.Email;
        entity.GrauParentesco = grauParentesco;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
