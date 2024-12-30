using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Commands.CreateProfissional;
public record CreateProfissionalCommand : IRequest<int>
{
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
    public int? LocalidadeId { get; init; }
    public bool Habilitado { get; init; }
    public string? ModalidadesIds { get; init; }
    public required int PerfilId { get; set; }
}

public class CreateProfissionalCommandHandler : IRequestHandler<CreateProfissionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProfissionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProfissionalCommand request, CancellationToken cancellationToken)
    {
        var perfil = await _context.Perfis
            .FindAsync([request.PerfilId], cancellationToken);

        Guard.Against.NotFound(request.PerfilId, perfil);

        Municipio? municipio = null;

        if (request.MunicipioId != null)
        {
            municipio = await _context.Municipios
                .FindAsync([request.MunicipioId], cancellationToken);

            Guard.Against.NotFound((int)request.MunicipioId, municipio);
        }

        Localidade? localidade = null;

        if (request.LocalidadeId != null)
        {
            localidade = await _context.Localidades
                .FindAsync([request.LocalidadeId], cancellationToken);

            Guard.Against.NotFound((int)request.LocalidadeId, localidade);
        }

        var list = new List<Modalidade>();

        if (!string.IsNullOrWhiteSpace(request.ModalidadesIds))
        {
            List<int> listIds = request.ModalidadesIds.Split(',').Select(s => Convert.ToInt32(s)).ToList();

            foreach (int id in listIds)
            {
                var Modalidade = await _context.Modalidades
                    .FindAsync([id], cancellationToken);

                list.Add(Modalidade!);
            }
        }
        else
        {
            list = null;
        }

        var entity = new Profissional
        {
            Nome = request.Nome!,
            DtNascimento = DateTime.ParseExact(request.DtNascimento!, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            Email = request.Email!,
            Sexo = request.Sexo!,
            CpfCnpj = request.Cpf!,
            Telefone = request.Telefone,
            Celular = request.Celular,
            Endereco = request.Endereco,
            Numero = request.Numero,
            Cep = request.Cep,
            Bairro = request.Bairro,
            Municipio = municipio,
            AspNetUserId = request.AspNetUserId,
            //Modalidades = list,
            Habilitado = request.Habilitado,
            Localidade = localidade,
            Perfil = perfil
        };

        _context.Profissionais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
