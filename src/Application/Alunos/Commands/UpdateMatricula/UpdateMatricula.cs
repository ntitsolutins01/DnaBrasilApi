using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateMatricula;

public record UpdateMatriculaCommand : IRequest <bool>
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

public class UpdateMatriculaCommandHandler : IRequestHandler<UpdateMatriculaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateMatriculaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateMatriculaCommand request, CancellationToken cancellationToken)
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

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
