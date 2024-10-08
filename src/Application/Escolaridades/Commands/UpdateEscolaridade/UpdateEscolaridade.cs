﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Escolaridades.Commands.UpdateEscolaridade;
using DnaBrasilApi.Domain.Entities;
namespace DnaBrasilApi.Application.Escolaridades.Commands.UpdateEscolaridade;

public record UpdateEscolaridadeCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; init; }
}

public class UpdateEscolaridadeCommandHandler : IRequestHandler<UpdateEscolaridadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEscolaridadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEscolaridadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Escolaridades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
