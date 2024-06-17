using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Notas.Commands.UpdateNota;

public record UpdateNotaCommand : IRequest <bool>
{
   public required int Id { get; init; }

   public decimal? PrimeiroBimestre { get; init; }

   public decimal? SegundoBimestre { get; init; }

   public decimal? TerceiroBimestre { get; init; }

   public decimal? QuartoBimestre { get; init; }

   public decimal? Media { get; init; }

   public bool Status { get; init; }
}

public class UpdateNotaCommandHandler : IRequestHandler<UpdateNotaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateNotaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateNotaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.PrimeiroBimestre = request.PrimeiroBimestre;
        entity.SegundoBimestre = request.SegundoBimestre;
        entity.TerceiroBimestre = request.TerceiroBimestre;
        entity.QuartoBimestre = request.QuartoBimestre;
        entity.Media = request.Media;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
