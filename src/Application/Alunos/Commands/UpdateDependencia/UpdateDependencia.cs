using DnaBrasilApi.Application.Alunos.Commands.CreateDependencia;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateDependencia;

public record UpdateDependenciaCommand : IRequest
{
    public int Id { get; set; }
    public string? Doencas { get; init; }
    public string? Nacionalidade { get; init; }
    public string? Naturalidade { get; init; }
    public string? NomeEscola { get; init; }
    public string? TipoEscola { get; init; }
    public string? TipoEscolaridade { get; init; }
    public string? Turno { get; init; }
    public string? Serie { get; init; }
    public string? Ano { get; init; }
    public string? Turma { get; init; }
    public bool? TermoCompromisso { get; init; }
    public bool? AutorizacaoUsoImagemAudio { get; init; }
    public bool? AutorizacaoUsoIndicadores { get; init; }
    public bool? AutorizacaoSaida { get; init; } = false;
    public required Aluno Aluno { get; init; }
}

public class UpdateDependenciaCommandHandler : IRequestHandler<UpdateDependenciaCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDependenciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDependenciaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Dependencias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Doencas = request.Doencas;
        entity.Nacionalidade = request.Nacionalidade;
        entity.Naturalidade = request.Naturalidade;
        entity.NomeEscola = request.NomeEscola;
        entity.TipoEscola = request.TipoEscola;
        entity.TipoEscolaridade = request.TipoEscolaridade;
        entity.Turno = request.Turno;
        entity.Serie = request.Serie;
        entity.Ano = request.Ano;
        entity.Turma = request.Turma;
        entity.TermoCompromisso = request.TermoCompromisso;
        entity.AutorizacaoUsoImagemAudio = request.AutorizacaoUsoImagemAudio;
        entity.AutorizacaoUsoIndicadores = request.AutorizacaoUsoIndicadores;
        entity.AutorizacaoSaida = request.AutorizacaoSaida;
        entity.Aluno = request.Aluno;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
