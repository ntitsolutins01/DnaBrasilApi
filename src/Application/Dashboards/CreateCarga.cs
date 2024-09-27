using DnaBrasilApi.Application.Common.Interfaces;
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
            .Include(i => i.Aluno)
            .Include(i => i.QualidadeDeVida)
            .Include(i => i.Vocacional)
            .Include(i => i.ConsumoAlimentar)
            .Include(i => i.TalentoEsportivo)
            .Include(i => i.Saude)
            .Include(i => i.SaudeBucal)
            //.Include(i => i.Dependencia)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        //var list = await _context.QualidadeDeVidas
        //    .Include(i => i.Aluno)
        //    .AsNoTracking()
        //    .ToListAsync(cancellationToken);

        var list = await _context.ConsumoAlimentares
            .Include(i => i.Aluno)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var alunos = await _context.Alunos
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        foreach (Aluno aluno in alunos)
        {
            var alunoObj = await _context.Alunos
                .FindAsync(new object[] { aluno!.Id }, cancellationToken);

            //var find = list.Find(
            //    delegate (QualidadeDeVida bk)
            //    {
            //        return bk.Aluno!.Id == aluno.Id;
            //    }
            //);
            var find = list.Find(
                delegate (ConsumoAlimentar bk)
                {
                    return bk.Aluno!.Id == aluno.Id;
                }
            );

            if (find != null)
            {
                var findLaudos = laudos.Find(
                    delegate (Laudo bk)
                    {
                        return bk.Aluno!.Id == aluno.Id;
                    }
                );

                //var obj = await _context.QualidadeDeVidas
                //    .FindAsync(new object[] { find!.Id }, cancellationToken);
                var obj = await _context.ConsumoAlimentares
                    .FindAsync(new object[] { find!.Id }, cancellationToken);

                if (findLaudos != null)
                {

                    var entity = await _context.Laudos
                        .FindAsync(new object[] { findLaudos.Id }, cancellationToken);

                    Guard.Against.NotFound(request.Id, entity);

                    if (
                        //findLaudos.QualidadeDeVida == null
                        //&&
                        //findLaudos.Vocacional == null
                        //&&
                        //findLaudos.Saude == null
                        //&&
                        findLaudos.ConsumoAlimentar == null 
                        //&&
                        //findLaudos.SaudeBucal == null 
                        //&&
                        //findLaudos.TalentoEsportivo == null
                        )
                    {
                        //entity.StatusLaudo = "F";

                        //var results = await _context.SaveChangesAsync(cancellationToken);

                        //var teste = results == 1;//true

                        //entity.QualidadeDeVida = obj;
                        entity.ConsumoAlimentar = obj;


                        var results = await _context.SaveChangesAsync(cancellationToken);
                    }
                }
                else
                {
                    var entityLaudo = new Laudo()
                    {
                        Aluno = alunoObj!,
                        //QualidadeDeVida = obj
                        ConsumoAlimentar = obj
                    };

                    _context.Laudos.Add(entityLaudo);

                    await _context.SaveChangesAsync(cancellationToken);

                    var id = entityLaudo.Id;
                }
            }

        }


        //foreach (var item in laudos)
        //{
        //    // Find a book by its ID.
        //    //var find = list.Find(
        //    //    delegate (QualidadeDeVida bk)
        //    //    {
        //    //        return bk.Aluno!.Id == item.Aluno.Id;
        //    //    }
        //    //);

        //    //if (find == null)
        //    //{
        //    //    continue;
        //    //}

        //    //var obj = await _context.QualidadeDeVidas
        //    //    .FindAsync(new object[] { find!.Id }, cancellationToken);

        //    var entity = await _context.Laudos
        //        .FindAsync(new object[] { item.Id }, cancellationToken);

        //    Guard.Against.NotFound(request.Id, entity);

        //    if (
        //        item.QualidadeDeVida != null
        //        &&
        //        item.Vocacional != null
        //        &&
        //        item.Saude != null
        //        &&
        //        item.ConsumoAlimentar != null
        //        &&
        //        item.SaudeBucal != null
        //        &&
        //        item.TalentoEsportivo != null
        //        )
        //    {
        //        entity.StatusLaudo = "F";

        //        var results = await _context.SaveChangesAsync(cancellationToken);

        //        var teste = results == 1;//true

        //        //entity.QualidadeDeVida = obj;


        //        //var results = await _context.SaveChangesAsync(cancellationToken);
        //    }



        //}

        // var result = await _context.SaveChangesAsync(cancellationToken);

        return 1;//true
    }
}
