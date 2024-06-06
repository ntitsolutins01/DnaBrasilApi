using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Usuarios.Commands.UpdateUsuario;

public record UpdateUsuarioCommand : IRequest<bool>
{
    public int Id { get; init; }
    public bool Status { get; init; }
    public required string AspNetUserId { get; init; }
    public required string Nome { get; init; }
    public required string TipoPessoa { get; init; }
    public required string CpfCnpj { get; init; }
    public required string Email { get; init; }
    public required string AspNetRoleId { get; init; }
    public required int PerfilId { get; init; }
    public required int MunicipioId { get; init; }
}

public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateUsuarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Usuarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var municipio = await _context.Municipios
            .FindAsync(new object[] { request.MunicipioId }, cancellationToken);

        var perfil = await _context.Perfis
            .FindAsync(new object[] { request.PerfilId }, cancellationToken);

        entity.Nome = request.Nome;
        entity.Email = request.Email;
        entity.Status = request.Status;
        entity.Perfil = perfil!;
        entity.AspNetRoleId = request.AspNetRoleId;
        entity.AspNetUserId = request.AspNetUserId;
        entity.Municipio = municipio;
        entity.CpfCnpj = request.CpfCnpj;
        entity.TipoPessoa = request.TipoPessoa;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
