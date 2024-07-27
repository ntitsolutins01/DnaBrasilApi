using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateDependencia;

public record UpdateDependenciaCommand : IRequest<bool>
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
    public required int AlunoId { get; init; }
}

public class UpdateDependenciaCommandHandler : IRequestHandler<UpdateDependenciaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateDependenciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateDependenciaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Dependencias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        //var aluno = await _context.Alunos
        //    .FindAsync(new object[] { request.AlunoId }, cancellationToken);

        //Guard.Against.NotFound(request.AlunoId, aluno);

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
        //entity.Aluno = aluno;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
