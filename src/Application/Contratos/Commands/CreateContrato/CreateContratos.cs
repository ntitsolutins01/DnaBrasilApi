﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Contratos.Commands.CreateContrato;
public record CreateContratoCommand : IRequest<int>
{
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public required DateTime DtIni { get; set; }
    public required DateTime DtFim { get; set; }
    public string? Anexo { get; set; }
    public bool Status { get; set; } = true;
}

public class CreateContratoCommandHandler : IRequestHandler<CreateContratoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateContratoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateContratoCommand request, CancellationToken cancellationToken)
    {
        var entity = new Contrato
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            DtIni = request.DtIni,
            DtFim = request.DtFim,
            Anexo = request.Anexo,
            Status = request.Status

        };

        _context.Contratos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
