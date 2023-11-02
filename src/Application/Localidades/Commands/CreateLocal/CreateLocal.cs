﻿using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Locais.Commands.CreateLocal;
public record CreateLocalCommand : IRequest<int>
{
    public required string? Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; set; } = true;
    public required Municipio? Municipio { get; init; }
    public required List<Contrato>? Contratos { get; init; }
}

public class CreateLocalCommandHandler : IRequestHandler<CreateLocalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateLocalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLocalCommand request, CancellationToken cancellationToken)
    {
        var entity = new Localidade
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Status = request.Status,
            Municipio = request.Municipio,
            Contratos = request.Contratos
        };

        _context.Localidades.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}