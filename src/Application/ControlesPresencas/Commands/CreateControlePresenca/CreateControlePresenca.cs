﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesPresencas.Commands.CreateControlePresenca;

public record CreateControlePresencaCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public int? EventoId { get; init; }
    public required string Controle { get; init; }
    public string? Justificativa { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateControlePresencaCommandHandler : IRequestHandler<CreateControlePresencaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateControlePresencaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateControlePresencaCommand request, CancellationToken cancellationToken)
    {

        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        Evento? evento = null;

        if (request.EventoId != null)
        {
            evento = await _context.Eventos.FindAsync(new object[] { request.EventoId }, cancellationToken);

            Guard.Against.NotFound((int)request.EventoId, evento);
        }

        var entity = new ControlePresenca
        {
            Aluno = aluno,
            Evento = evento,
            Controle = request.Controle,
            Justificativa = request.Justificativa,
            Status = request.Status,

        };

        _context.ControlesPresencas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
