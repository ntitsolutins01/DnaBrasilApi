using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAluno;
public record DeleteAlunoCommand(int Id) : IRequest<bool>;

public class DeleteAlunoCommandHandler : IRequestHandler<DeleteAlunoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var possuiLaudos = _context.Laudos.Any(x => x.Aluno.Id == request.Id);

        Guard.Against.PossuiLaudos(possuiLaudos);

        _context.Alunos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}


//delete from Saudes where AlunoId = 51270
//delete from TalentosEsportivos where AlunoId = 51270
//delete from ConsumoAlimentares where AlunoId = 51270
//delete from QualidadeDeVidas where AlunoId = 51270
//delete from Vocacionais where AlunoId = 51270

//delete from Alunos where Id = 51270

//delete from Laudos Where  AlunoId in (45477)
//delete from Saudes where AlunoId = 45477
//delete from TalentosEsportivos where AlunoId = 45477
//delete from ConsumoAlimentares where AlunoId = 45477
//delete from QualidadeDeVidas where AlunoId = 45477
//delete from Vocacionais where AlunoId = 45477

//delete from Alunos where Id = 45477

//delete from Alunos where Id = 51269

//delete from Laudos Where  AlunoId in (45515)
//delete from Saudes where AlunoId = 45515
//delete from TalentosEsportivos where AlunoId = 45515
//delete from ConsumoAlimentares where AlunoId = 45515
//delete from QualidadeDeVidas where AlunoId = 45515
//delete from Vocacionais where AlunoId = 45515
//delete from Alunos where Id = 45515
//delete from Alunos where Id = 51225

//delete from Laudos Where  AlunoId in (51242)
//delete from Saudes where AlunoId = 51242
//delete from TalentosEsportivos where AlunoId = 51242
//delete from ConsumoAlimentares where AlunoId = 51242
//delete from QualidadeDeVidas where AlunoId = 51242

//delete from Laudos where VocacionalId = 2152
//delete from Vocacionais where Id = 2152
//delete from Alunos where Id = 51242

//delete from Laudos Where  AlunoId in (51272)
//delete from Saudes where AlunoId = 51272
//delete from TalentosEsportivos where AlunoId = 51272
//delete from ConsumoAlimentares where AlunoId = 51272
//delete from QualidadeDeVidas where AlunoId = 51272
//delete from Vocacionais where AlunoId = 51272

//delete from Alunos where Id = 51272

//SELECT nome, COUNT(nome) 
//    FROM Alunos
//where LocalidadeId = 49
//GROUP BY nome
//    HAVING COUNT(nome) > 1
