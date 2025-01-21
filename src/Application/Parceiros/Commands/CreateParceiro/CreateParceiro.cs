using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Parceiros.Commands.CreateParceiro;

public record CreateParceiroCommand : IRequest<int>
{
    public string? AspNetUserId { get; init; }
    public int? MunicipioId { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required int TipoParceriaId { get; init; }
    public required string TipoPessoa { get; init; }
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

public class CreateParceiroCommandHandler : IRequestHandler<CreateParceiroCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateParceiroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateParceiroCommand request, CancellationToken cancellationToken)
    {
        Municipio? municipio = null;

        if (request.MunicipioId != null)
        {
            municipio = await _context.Municipios
                .FindAsync(new object[] { request.MunicipioId }, cancellationToken);

            Guard.Against.NotFound((int)request.MunicipioId, municipio);
        }

        var tipoParceria = await _context.TiposParcerias
            .FindAsync(new object[] { request.TipoParceriaId }, cancellationToken);

        Guard.Against.NotFound(request.TipoParceriaId, tipoParceria);

        var entity = new Parceiro
        {
            Nome = request.Nome,
            Status = request.Status,
            Alunos = request.Alunos,
            TipoParceria = tipoParceria,
            TipoPessoa = request.TipoPessoa,
            Celular = request.Celular,
            Telefone = request.Telefone,
            CpfCnpj = request.CpfCnpj,
            Cep = request.Cep,
            Endereco = request.Endereco,
            Municipio = municipio,
            AspNetUserId = request.AspNetUserId,
            Habilitado = request.Habilitado,
            Email = request.Email,
            Bairro = request.Bairro,
            Numero = request.Numero!,
            RazaoSocial = request.RazaoSocial,
            NomeContato = request.NomeContato,

        };

        _context.Parceiros.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
