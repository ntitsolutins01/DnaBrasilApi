using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Parceiros.Commands.CreateParceiro;

public record CreateParceiroCommand : IRequest<int>
{
    public string? AspNetUserId { get; set; }
    public int? MunicipioId { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required int TipoParceria { get; set; }
    public required string TipoPessoa { get; set; }
    public required string CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public int? Numero { get; set; }
    public string? Bairro { get; set; }
    public bool Status { get; set; }
    public bool? Habilitado { get; set; }
    public List<Aluno>? Alunos { get; set; }
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

        var entity = new Parceiro
        {
            Nome = request.Nome,
            Status = request.Status,
            Alunos = request.Alunos,
            TipoParceria = request.TipoParceria,
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

        };

        _context.Parceiros.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
