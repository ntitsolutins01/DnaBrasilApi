using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.VocacionalByAluno;

public record GetVocacionalByAlunoQuery : IRequest<VocacionalDto>
{
}

public class GetVocacionalByAlunoQueryValidator : AbstractValidator<GetVocacionalByAlunoQuery>
{
    public GetVocacionalByAlunoQueryValidator()
    {
    }
}

public class GetVocacionalByAlunoQueryHandler : IRequestHandler<GetVocacionalByAlunoQuery, VocacionalDto>
{
    private readonly IApplicationDbContext _context;

    public GetVocacionalByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<VocacionalDto> Handle(GetVocacionalByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
