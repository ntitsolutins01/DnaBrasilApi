using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Commands.UpdateProfissional;

public record UpdateProfissionalCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? AspNetUserId { get; init; }
    public string? Nome { get; init; }
    public string? DtNascimento { get; init; }
    public string? Email { get; init; }
    public string? Sexo { get; init; }
    public string? Cpf { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Endereco { get; init; }
    public int? Numero { get; init; }
    public string? Cep { get; init; }
    public string? Bairro { get; init; }
    public bool Status { get; init; } = true;
    public int? MunicipioId { get; init; }
    public bool Habilitado { get; init; }
    public string? AmbientesIds { get; init; }
}

public class UpdateProfissionalCommandHandler : IRequestHandler<UpdateProfissionalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateProfissionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProfissionalCommand request, CancellationToken cancellationToken)
    {
        Municipio? municipio = null;

        if (request.MunicipioId != null)
        {
            municipio = await _context.Municipios
                .FindAsync(new object[] { request.MunicipioId }, cancellationToken);
        }

        var entity = await _context.Profissionais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome!;
        entity.DtNascimento = request.DtNascimento == "" ? null : Convert.ToDateTime(request.DtNascimento);
        entity.Email = request.Email!;
        entity.Sexo = request.Sexo;
        entity.Telefone = request.Telefone;
        entity.Celular = request.Celular;
        entity.Endereco = request.Endereco;
        entity.Numero = request.Numero;
        entity.Cep = request.Cep;
        entity.Bairro = request.Bairro;
        entity.Municipio = municipio;
        entity.Status = request.Status;
        entity.Habilitado = request.Habilitado;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
