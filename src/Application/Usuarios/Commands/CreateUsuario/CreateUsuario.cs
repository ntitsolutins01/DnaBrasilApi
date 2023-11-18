using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Usuarios.Commands.CreateUsuario;

public record CreateUsuarioCommand : IRequest<int>
{
    public required string AspNetUserId { get; init; }
    public required string Nome { get; init; }
    public required string Cpf { get; init; }
    public required string Email { get; init; }
    public required string AspNetRoleId { get; init; }
}

public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateUsuarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var entity = new Usuario
        {
            Nome = request.Nome,
            AspNetUserId = request.AspNetUserId,
            Cpf = request.Cpf,
            Email = request.Email,
            AspNetRoleId = request.AspNetRoleId 
        };

        _context.Usuarios.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
