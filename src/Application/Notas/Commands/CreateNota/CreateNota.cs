using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Notas.Commands.CreateNota;
public record CreateNotaCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required int DisciplinaId { get; init; }
    public decimal PrimeiroBimestre { get; init; }
    public decimal SegundoBimestre { get; init; }
    public decimal TerceiroBimestre { get; init; }
    public decimal QuartoBimestre { get; init; }
    public decimal Media { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateNotaCommandHandler : IRequestHandler<CreateNotaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateNotaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateNotaCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        var disciplina = await _context.Disciplinas
            .FindAsync([request.DisciplinaId], cancellationToken);

        Guard.Against.NotFound(request.DisciplinaId, disciplina);

        var media = (request.PrimeiroBimestre + request.SegundoBimestre + request.TerceiroBimestre +
                    request.QuartoBimestre) / 4;

        var entity = new Nota
        {
            Aluno = aluno,
            Disciplina = disciplina,
            PrimeiroBimestre = request.PrimeiroBimestre,
            SegundoBimestre = request.SegundoBimestre,
            TerceiroBimestre = request.TerceiroBimestre,
            QuartoBimestre = request.QuartoBimestre,
            Media = media,
            Status = request.Status
        };

        _context.Notas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
