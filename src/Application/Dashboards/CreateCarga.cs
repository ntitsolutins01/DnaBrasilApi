using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Deficiencias.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards;
public record CreateCargaCommand : IRequest<int>
{
    public required int Id { get; init; }
}

public class CreateCargaCommandHandler : IRequestHandler<CreateCargaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCargaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCargaCommand request, CancellationToken cancellationToken)
    {

        var laudos = await _context.Laudos
            .Include(i => i.QualidadeDeVida)
            .Include(i => i.Vocacional)
            .Include(i => i.Consumo)
            .Include(i => i.TalentoEsportivo)
            .Include(i => i.Saude)
            .Include(i => i.SaudeBucal)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var list = await _context.QualidadeDeVidas
            .Include(i => i.Aluno)
            .AsNoTracking()
            .ToListAsync(cancellationToken);



        foreach (var item in laudos)
        {
            // Find a book by its ID.
            //var find = list.Find(
            //    delegate (QualidadeDeVida bk)
            //    {
            //        return bk.Aluno!.Id == item.Aluno.Id;
            //    }
            //);

            //if (find == null)
            //{
            //    continue;
            //}

            //var obj = await _context.QualidadeDeVidas
            //    .FindAsync(new object[] { find!.Id }, cancellationToken);

            var entity = await _context.Laudos
                .FindAsync(new object[] { item.Id }, cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            if (item.QualidadeDeVida != null &&
                item.Vocacional != null &&
                item.Saude != null &&
                item.Consumo != null &&
                item.SaudeBucal != null &&
                item.TalentoEsportivo != null)
            {
                entity.StatusLaudo = "F";

                var results = await _context.SaveChangesAsync(cancellationToken);

                var teste = results == 1;//true
            }


        }

        //var result = await _context.SaveChangesAsync(cancellationToken);

        return 1;//true
    }
}
