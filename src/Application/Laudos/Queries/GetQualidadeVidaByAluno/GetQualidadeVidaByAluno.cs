using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Laudos.Queries.QualidadeVidaByAluno;

namespace DnaBrasil.Application.Laudos.Queries.GetQualidadeVidaByAluno;

public record GetQualidadeVidaByAlunoQuery : IRequest<QualidadeVidaDto>
{
}

public class GetQualidadeVidaByAlunoQueryValidator : AbstractValidator<GetQualidadeVidaByAlunoQuery>
{
    public GetQualidadeVidaByAlunoQueryValidator()
    {
    }
}

public class GetQualidadeVidaByAlunoQueryHandler : IRequestHandler<GetQualidadeVidaByAlunoQuery, QualidadeVidaDto>
{
    private readonly IApplicationDbContext _context;

    public GetQualidadeVidaByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<QualidadeVidaDto> Handle(GetQualidadeVidaByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
