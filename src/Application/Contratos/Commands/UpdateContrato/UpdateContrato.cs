﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Contratos.Commands.UpdateContrato;

public record UpdateContratoCommand : IRequest
{
    public int Id { get; init; }
    public required string Nome { get; set; }
    public required string? Descricao { get; set; }
    public required DateTime DtIni { get; set; }
    public required DateTime DtFim { get; set; }
    public string? Anexo { get; set; }
    public bool Status { get; set; } = true;
    public List<Localidade>? Locais { get; set; }
    public List<Aluno>? Alunos { get; set; }
    public List<Profissional>? Profissionais { get; set; }
}

public class UpdateContratoCommandHandler : IRequestHandler<UpdateContratoCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateContratoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateContratoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contratos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.DtFim = request.DtFim;
        entity.DtIni = request.DtIni;
        entity.Anexo = request.Anexo;
        entity.Alunos = request.Alunos;
        entity.Status = request.Status;
        entity.Localidades = request.Locais;
        entity.Profissionais = request.Profissionais;
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
