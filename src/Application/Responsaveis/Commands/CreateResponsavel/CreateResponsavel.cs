using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Responsaveis.Commands.CreateResponsavel;
public record CreateResponsavelCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required string Cpf { get; init; }
    public required string Telefone { get; init; }
    public string? Email { get; init; }
    public required int GrauParentescoId { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateResponsavelCommandHandler : IRequestHandler<CreateResponsavelCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateResponsavelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateResponsavelCommand request, CancellationToken cancellationToken)
    {
        var grauParentesco = await _context.GrauParentescos.FindAsync([request.GrauParentescoId], cancellationToken);

        Guard.Against.NotFound((int)request.GrauParentescoId!, grauParentesco);

        var entity = new Responsavel
        {
            Nome = request.Nome,
            Cpf = request.Cpf,
            Telefone = request.Telefone,
            Email = request.Email,
            GrauParentesco = grauParentesco,
        };

        _context.Responsaveis.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
