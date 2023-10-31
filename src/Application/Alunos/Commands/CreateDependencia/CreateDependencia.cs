using DnaBrasil.Application.Alunos.Commands.CreateDependencia;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Commands.CreateDependencia;

public record CreateDependenciaCommand : IRequest<int>
{
    public string? Doencas { get; init; }
    public string? Nacionalidade { get; init; }
    public string? Naturalidade { get; init; }
    public string? NomeEscola { get; init; }
    public int TipoEscola { get; init; }
    public int TipoEscolaridade { get; init; }
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

public class CreateDependenciaCommandHandler : IRequestHandler<CreateDependenciaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDependenciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDependenciaCommand request, CancellationToken cancellationToken)
    {

        var entity = new Dependencia()
        {
            Doencas = request.Doencas,
            Nacionalidade = request.Nacionalidade,
            Naturalidade = request.Naturalidade,
            NomeEscola = request.NomeEscola,
            TipoEscola = request.TipoEscola,
            TipoEscolaridade = request.TipoEscolaridade,
            Turno = request.Turno,
            Serie = request.Serie,
            Ano = request.Ano,
            Turma = request.Turma,
            TermoCompromisso = request.TermoCompromisso,
            AutorizacaoUsoImagemAudio = request.AutorizacaoUsoImagemAudio,
            AutorizacaoUsoIndicadores = request.AutorizacaoUsoIndicadores,
            AutorizacaoSaida = request.AutorizacaoSaida,
            Aluno = request.Aluno
        };

        _context.Dependencias.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
