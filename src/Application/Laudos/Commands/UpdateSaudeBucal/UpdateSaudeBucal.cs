﻿using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Commands.UpdateSaudeBucal;

public record UpdateSaudeBucalCommand : IRequest
{
    public int Id { get; init; }
    public required string Resposta { get; init; }
}

public class UpdateSaudeBucalCommandHandler : IRequestHandler<UpdateSaudeBucalCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.SaudeBucais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Resposta = request.Resposta;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
