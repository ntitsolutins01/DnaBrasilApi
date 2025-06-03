using DnaBrasilApi.Application.Common.Interfaces;

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
            .Include(i => i.Aluno.Localidade)
            .Include(i => i.QualidadeDeVida)
            .Include(i => i.Vocacional)
            .Include(i => i.ConsumoAlimentar)
            .Include(i => i.TalentoEsportivo)
            .Include(i => i.SaudeBucal)
            .Include(i => i.Saude)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        ////var list = await _context.QualidadeDeVidas
        ////    .Include(i => i.Aluno)
        ////    .AsNoTracking()
        ////    .ToListAsync(cancellationToken);

        ////var list = await _context.Vocacionais
        ////    .Include(i => i.Aluno)
        ////    .AsNoTracking()
        ////    .ToListAsync(cancellationToken);

        ////var list = await _context.ConsumoAlimentares
        ////    .Include(i => i.Aluno)
        ////    .AsNoTracking()
        ////    .ToListAsync(cancellationToken);

        ////var list = await _context.TalentosEsportivos
        ////    .Include(i => i.Aluno)
        ////    .AsNoTracking()
        ////    .ToListAsync(cancellationToken);

        ////var list = await _context.SaudeBucais
        ////    .Include(i => i.Aluno)
        ////    .AsNoTracking()
        ////    .ToListAsync(cancellationToken);

        //var list = await _context.Saudes
        //    .Include(i => i.Aluno)
        //    .AsNoTracking()
        //    .ToListAsync(cancellationToken);

        ////var arrAlunos = new int[]
        ////{
        ////    };

        //var alunos = await _context.Alunos
        //    .Where(q => q.Localidade.Id == 31)
        //    .AsNoTracking()
        //    .ToListAsync(cancellationToken);

        //foreach (Aluno aluno in alunos)
        //{
        //    var alunoObj = await _context.Alunos
        //        .FindAsync(new object[] { aluno!.Id }, cancellationToken);


        //    //var find = list.Find(
        //    //    delegate (QualidadeDeVida bk)
        //    //    {
        //    //        return bk.Aluno!.Id == aluno.Id;
        //    //    }
        //    //);
        //    //var find = list.Find(
        //    //    delegate (Vocacional bk)
        //    //    {
        //    //        return bk.Aluno!.Id == aluno.Id;
        //    //    }
        //    //);
        //    //var find = list.Find(
        //    //    delegate (ConsumoAlimentar bk)
        //    //    {
        //    //        return bk.Aluno!.Id == aluno.Id;
        //    //    }
        //    //);
        //    //var find = list.Find(
        //    //    delegate (TalentoEsportivo bk)
        //    //    {
        //    //        return bk.Aluno!.Id == aluno.Id;
        //    //    }
        //    //);
        //    //var find = list.Find(
        //    //    delegate (SaudeBucal bk)
        //    //    {
        //    //        return bk.Aluno!.Id == aluno.Id;
        //    //    }
        //    //);
        //    var find = list.Find(
        //        delegate (Saude bk)
        //        {
        //            return bk.Aluno!.Id == aluno.Id;
        //        }
        //    );
        //    if (find != null)
        //    {
        //        var findLaudos = laudos.Find(
        //            delegate (Laudo bk)
        //            {
        //                return bk.Aluno!.Id == aluno.Id;
        //            }
        //        );

        //        //var obj = await _context.QualidadeDeVidas
        //        //    .FindAsync(new object[] { find!.Id }, cancellationToken);
        //        //var obj = await _context.Vocacionais
        //        //    .FindAsync(new object[] { find!.Id }, cancellationToken);
        //        //var obj = await _context.ConsumoAlimentares
        //        //    .FindAsync(new object[] { find!.Id }, cancellationToken);
        //        //var obj = await _context.TalentosEsportivo
        //        //.FindAsync(new object[] { find!.Id }, cancellationToken);
        //        //var obj = await _context.SaudeBucais
        //        //    .FindAsync([find!.Id], cancellationToken);
        //        var obj = await _context.Saudes
        //            .FindAsync(new object[] { find!.Id }, cancellationToken);

        //        if (findLaudos != null)
        //        {

        //            var entity = await _context.Laudos
        //                .FindAsync([findLaudos.Id], cancellationToken);

        //            Guard.Against.NotFound(request.Id, entity);

        //            if (
        //            //findLaudos.QualidadeDeVida != null
        //            //&&
        //            //findLaudos.Vocacional != null
        //            //&&
        //            findLaudos.Saude != null
        //            //&&
        //            //findLaudos.ConsumoAlimentar != null
        //            //&&
        //            //findLaudos.SaudeBucal != null
        //            //&&
        //            //findLaudos.TalentoEsportivo != null
        //               )
        //            {
        //                //entity.StatusLaudo = "A";

        //                //var results = await _context.SaveChangesAsync(cancellationToken);

        //                //var teste = results == 1;//true

        //                //entity.QualidadeDeVida = obj;
        //                //entity.Vocacional = obj;
        //                //entity.ConsumoAlimentar = obj;
        //                //entity.TalentoEsportivo = obj;
        //                //entity.SaudeBucal = obj;
        //                entity.Saude = obj;


        //                var results = await _context.SaveChangesAsync(cancellationToken);
        //            }
        //        }
        //        else
        //        {
        //            var entityLaudo = new Laudo()
        //            {
        //                Aluno = alunoObj!,
        //                //QualidadeDeVida = obj
        //                //Vocacional = obj
        //                //ConsumoAlimentar = obj
        //                //TalentoEsportivo = obj
        //                //SaudeBucal = obj
        //                Saude = obj
        //            };

        //            _context.Laudos.Add(entityLaudo);

        //            await _context.SaveChangesAsync(cancellationToken);

        //            var id = entityLaudo.Id;
        //        }
        //    }
        //}
        var arr = new int[]
        {
            30,31
        };

        laudos = laudos.ToList();// x.Aluno.Localidade!.Id == 31).ToList();

        var count = laudos.Count();

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
                .FindAsync([item.Id], cancellationToken);

            Guard.Against.NotFound(item.Id, entity);

            var idade = GetIdade(item.Aluno.DtNascimento, DateTime.Now);

            switch (idade)
            {
                case >= 14:
                    if (
                        item.QualidadeDeVida != null
                        &&
                        item.Vocacional != null
                        &&
                        item.Saude != null
                        &&
                        item.ConsumoAlimentar != null
                        &&
                        item.SaudeBucal != null
                        &&
                        item.TalentoEsportivo != null
                    )
                    {
                        entity.StatusLaudo = "F";

                        var results = await _context.SaveChangesAsync(cancellationToken);

                        var teste = results == 1;//true
                    }
                    //else
                    //{
                    //    entity.StatusLaudo = "A";

                    //    var results = await _context.SaveChangesAsync(cancellationToken);

                    //    var teste = results == 1;//true
                    //}
                    break;
                case >= 12:
                    if (
                        item.QualidadeDeVida != null
                        &&
                        item.Saude != null
                        &&
                        item.ConsumoAlimentar != null
                        &&
                        item.SaudeBucal != null
                        &&
                        item.TalentoEsportivo != null
                    )
                    {
                        entity.StatusLaudo = "F";

                        var results = await _context.SaveChangesAsync(cancellationToken);

                        var teste = results == 1;//true
                    }
                    //else
                    //{
                    //    entity.StatusLaudo = "A";

                    //    var results = await _context.SaveChangesAsync(cancellationToken);

                    //    var teste = results == 1;//true
                    //}
                    break;
                default:
                    if (
                        item.Saude != null
                        &&
                        item.ConsumoAlimentar != null
                        &&
                        item.SaudeBucal != null
                        &&
                        item.TalentoEsportivo != null
                    )
                    {
                        entity.StatusLaudo = "F";

                        var results = await _context.SaveChangesAsync(cancellationToken);

                        var teste = results == 1;//true
                    }
                    //else
                    //{
                    //    entity.StatusLaudo = "A";

                    //    var results = await _context.SaveChangesAsync(cancellationToken);

                    //    var teste = results == 1;//true
                    //}
                    break;
            }
        }


        return 1;//true
    }

    private static int GetIdade(DateTime data, DateTime? now = null)
    {
        // Carrega a data do dia para compara��o caso data informada seja nula

        now = ((now == null) ? DateTime.Now : now);

        try
        {
            int YearsOld = (now.Value.Year - data.Year);

            if (now.Value.Month < data.Month || (now.Value.Month == data.Month && now.Value.Day < data.Day))
            {
                YearsOld--;
            }

            return YearsOld > 18 ? 99 : YearsOld < 4 ? 4 : YearsOld;
        }
        catch
        {
            return 0;
        }
    }
}
