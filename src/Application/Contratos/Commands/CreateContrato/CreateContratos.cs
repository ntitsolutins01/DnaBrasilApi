﻿using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Contratos.Commands.CreateContrato;
public record CreateContratoCommand : IRequest<int>
{
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
            Alunos = request.Alunos,
            Anexo = request.Anexo,
            Locais = request.Locais,
            Profissionais = request.Profissionais,
            Status = request.Status

        };

        _context.Contratos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
