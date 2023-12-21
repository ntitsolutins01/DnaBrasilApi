﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Commands.CreateProfissional;
public record CreateProfissionalCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public DateTime DtNascimento { get; init; }
    public required string Email { get; init; }
    public required string Sexo { get; init; }
    public required string CpfCnpj { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Endereco { get; init; }
    public int Numero { get; init; }
    public string? Cep { get; init; }
    public string? Bairro { get; init; }
    public bool Status { get; init; } = true;
    public int? MunicipioId { get; init; }
    public int AspNetUserId { get; init; }
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
        Municipio? municipio = null;

        if (request.MunicipioId != null)
        {
            municipio = await _context.Municipios
                .FindAsync(new object[] { request.MunicipioId }, cancellationToken);
        }

        var entity = new Profissional
        {
            Nome = request.Nome,
            DtNascimento = request.DtNascimento,
            Email = request.Email,
            Sexo = request.Sexo,
            CpfCnpj = request.CpfCnpj,
            Telefone = request.Telefone,
            Celular = request.Celular,
            Endereco = request.Endereco,
            Numero = request.Numero,
            Cep = request.Cep,
            Bairro = request.Bairro,
            Municipio = municipio,
            AspNetUserId = request.AspNetUserId
        };

        _context.Profissionais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
