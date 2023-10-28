using System.Xml;
using DnaBrasil.Application.Alunos.Commands.CreateMatricula;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Commands.CreateMatricula;

public record CreateMatriculaCommand : IRequest<int>
{
    public int Id { get; set; }
    public DateTime DtVencimentoParq { get; set; }
    public DateTime DtVencimentoAtestadoMedico { get; set; }
    public string? NomeResponsavel1 { get; set; }
    public string? ParentescoResponsavel1 { get; set; }
    public string? CpfResponsavel1 { get; set; }
    public string? NomeResponsavel2 { get; set; }
    public string? ParentescoResponsavel2 { get; set; }
    public string? CpfResponsavel2 { get; set; }
    public string? NomeResponsavel3 { get; set; }
    public string? ParentescoResponsavel3 { get; set; }
    public string? CpfResponsavel3 { get; set; }
}

public class CreateMatriculaCommandHandler : IRequestHandler<CreateMatriculaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMatriculaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMatriculaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Matriculas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.DtVencimentoParq = request.DtVencimentoParq;
        entity.DtVencimentoAtestadoMedico = request.DtVencimentoAtestadoMedico;
        entity.ParentescoResponsavel1 = request.ParentescoResponsavel1;
        entity.NomeResponsavel1 = request.NomeResponsavel1;
        entity.CpfResponsavel1 = request.CpfResponsavel1;
        entity.NomeResponsavel2 = request.NomeResponsavel2;
        entity.CpfResponsavel2 = request.CpfResponsavel2;
        entity.ParentescoResponsavel2 = request.ParentescoResponsavel2;
        entity.NomeResponsavel3 = request.NomeResponsavel3;
        entity.CpfResponsavel3 = request.CpfResponsavel3;
        entity.ParentescoResponsavel3 = request.ParentescoResponsavel3;

        _context.Matriculas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
