using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Parceiros.Commands.UpdateParceiro;

public record UpdateParceiroCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? AspNetUserId { get; init; }
    public int? MunicipioId { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required string CpfCnpj { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Cep { get; init; }
    public string? Endereco { get; init; }
    public int? Numero { get; init; }
    public string? Bairro { get; init; }
    public bool Status { get; init; }
    public bool? Habilitado { get; init; }
    public List<Aluno>? Alunos { get; init; }
    public required string RazaoSocial { get; init; }
    public string? NomeContato { get; init; }
}

public class UpdateParceiroCommandHandler : IRequestHandler<UpdateParceiroCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateParceiroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateParceiroCommand request, CancellationToken cancellationToken)
    {
        Municipio? municipio = null;
        if (request.MunicipioId != null)
        {
            municipio = await _context.Municipios
                .FindAsync(new object[] { request.MunicipioId }, cancellationToken);
            Guard.Against.NotFound((int)request.MunicipioId, municipio);
        }

        var entity = await _context.Parceiros
            .FindAsync(new object[] { request.Id }, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);

        entity!.Nome = request.Nome;
        entity.Status = request.Status;
        entity.Alunos = request.Alunos;
        entity.Celular = request.Celular;
        entity.Telefone = request.Telefone;
        entity.CpfCnpj = request.CpfCnpj;
        entity.Cep = request.Cep;
        entity.Endereco = request.Endereco;
        entity.Municipio = municipio;
        entity.Habilitado = request.Habilitado;
        entity.Email = request.Email;
        entity.Bairro = request.Bairro;
        entity.Numero = request.Numero;
        entity.RazaoSocial = request.RazaoSocial;
        entity.NomeContato = request.NomeContato;

        // Se não tiver AspNetUserId e um novo for fornecido, atualiza
        if (string.IsNullOrEmpty(entity.AspNetUserId) && !string.IsNullOrEmpty(request.AspNetUserId))
        {
            entity.AspNetUserId = request.AspNetUserId;
        }

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result > 0; // Mudei para verificar se houve alguma alteração
    }
}
