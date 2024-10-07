﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateConsumoAlimentar;

public record CreateConsumoAlimentarCommand : IRequest<int>
{
    public int ProfissionalId { get; init; }
    public int AlunoId { get; init; }
    public required string Resposta { get; init; }
}

public class CreateConsumoAlimentarCommandHandler : IRequestHandler<CreateConsumoAlimentarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos.FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound((int)request.ProfissionalId, profissional);

        var entity = new ConsumoAlimentar
        {
            Profissional = profissional,
            Aluno = aluno,
            Respostas = request.Resposta
        };

        _context.ConsumoAlimentares.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
