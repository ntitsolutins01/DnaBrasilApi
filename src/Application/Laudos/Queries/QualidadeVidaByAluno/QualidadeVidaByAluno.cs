using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.QualidadeVidaByAluno;

public record QualidadeVidaByAlunoQuery : IRequest<QualidadeVidaDto>
{
}

public class QualidadeVidaByAlunoQueryValidator : AbstractValidator<QualidadeVidaByAlunoQuery>
{
    public QualidadeVidaByAlunoQueryValidator()
    {
    }
}

public class QualidadeVidaByAlunoQueryHandler : IRequestHandler<QualidadeVidaByAlunoQuery, QualidadeVidaDto>
{
    private readonly IApplicationDbContext _context;

    public QualidadeVidaByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<QualidadeVidaDto> Handle(QualidadeVidaByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
