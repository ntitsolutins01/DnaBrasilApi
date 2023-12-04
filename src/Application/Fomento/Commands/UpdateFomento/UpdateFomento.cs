﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomento.Commands.UpdateFomento;

public record UpdateFomentoCommand : IRequest <bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required int MunicipioId { get; init; }
    public required int LocalidadeId { get; init; }
}

public class UpdateFomentoCommandHandler : IRequestHandler<UpdateFomentoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateFomentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateFomentoCommand request, CancellationToken cancellationToken)
    {

        var municipio = await _context.Municipios
            .FindAsync(new object[] { request.MunicipioId }, cancellationToken);
        var localidade = await _context.Localidades
            .FindAsync(new object[] { request.MunicipioId }, cancellationToken);
        var entity = await _context.Fomentos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Municipio = municipio;
         entity.Localidade = localidade!;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
