﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Parceiros.Commands.UpdateParceiro;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Parceiros.Commands.UpdateParceiro;

public record UpdateParceiroCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? AspNetUserId { get; init; }
    public Municipio? Municipio { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required int TipoParceria { get; init; }
    public required string TipoPessoa { get; init; }
    public required string CpfCnpj { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Cep { get; init; }
    public string? Endereco { get; init; }
    public int Numero { get; init; }
    public string? Bairro { get; init; }
    public bool Status { get; init; }
    public bool? Habilitado { get; init; }
    public List<Aluno>? Alunos { get; init; }
}

public class UpdateParceiroCommandHandler : IRequestHandler<UpdateParceiroCommand,bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateParceiroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateParceiroCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Parceiros
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;
        entity.Nome = request.Nome;
        entity.Status = request.Status;
        entity.Alunos = request.Alunos;
        entity.TipoParceria = request.TipoParceria;
        entity.TipoPessoa = request.TipoPessoa;
        entity.Celular = request.Celular;
        entity.Telefone = request.Telefone;
        entity.CpfCnpj = request.CpfCnpj;
        entity.Cep = request.Cep;
        entity.Endereco = request.Endereco;
        entity.Municipio = request.Municipio;
        entity.AspNetUserId = request.AspNetUserId;
        entity.Habilitado = request.Habilitado;
        entity.Email = request.Email;
        entity.Bairro = request.Bairro;
        entity.Numero = request.Numero;


        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
