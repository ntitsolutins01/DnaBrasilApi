using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateMatricula;

public record CreateMatriculaCommand : IRequest<int>
{
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
    public int AlunoId { get; set; }
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
        var aluno = await _context.Alunos
            .FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        var entity = new Matricula
        {
            DtVencimentoParq = request.DtVencimentoParq,
            DtVencimentoAtestadoMedico = request.DtVencimentoAtestadoMedico,
            ParentescoResponsavel1 = request.ParentescoResponsavel1,
            NomeResponsavel1 = request.NomeResponsavel1,
            CpfResponsavel1 = request.CpfResponsavel1,
            NomeResponsavel2 = request.NomeResponsavel2,
            CpfResponsavel2 = request.CpfResponsavel2,
            ParentescoResponsavel2 = request.ParentescoResponsavel2,
            NomeResponsavel3 = request.NomeResponsavel3,
            CpfResponsavel3 = request.CpfResponsavel3,
            ParentescoResponsavel3 = request.ParentescoResponsavel3,
            Aluno = aluno

        };

        _context.Matriculas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
