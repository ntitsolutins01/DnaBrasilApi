using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Usuarios.Commands.CreateUsuario;

public record CreateUsuarioCommand : IRequest<int>
{
    public required string AspNetUserId { get; init; }
    public required string Nome { get; init; }
    public required string TipoPessoa { get; init; }
    public required string CpfCnpj { get; init; }
    public required string Email { get; init; }
    public required string AspNetRoleId { get; init; }
    public required int PerfilId { get; init; }
    public required int MunicipioId { get; init; }
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
        var municipio = await _context.Municipios
            .FindAsync(new object[] { request.MunicipioId }, cancellationToken);
        var perfil = await _context.Perfis
            .FindAsync(new object[] { request.PerfilId }, cancellationToken);

        var entity = new Usuario
        {
            Nome = request.Nome,
            AspNetUserId = request.AspNetUserId,
            TipoPessoa = request.TipoPessoa,
            CpfCnpj = request.CpfCnpj,
            Email = request.Email,
            AspNetRoleId = request.AspNetRoleId,
            Perfil = perfil!,
            Municipio = municipio
        };

        _context.Usuarios.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
