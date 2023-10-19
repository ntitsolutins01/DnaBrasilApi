using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Queries.ConsumoAlimentarByAluno;

public record ConsumoAlimentarByAlunoQuery : IRequest<ConsumoAlimentarDto>
{
}

public class ConsumoAlimentarByAlunoQueryValidator : AbstractValidator<ConsumoAlimentarByAlunoQuery>
{
    public ConsumoAlimentarByAlunoQueryValidator()
    {
    }
}

public class ConsumoAlimentarByAlunoQueryHandler : IRequestHandler<ConsumoAlimentarByAlunoQuery, ConsumoAlimentarDto>
{
    private readonly IApplicationDbContext _context;

    public ConsumoAlimentarByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<ConsumoAlimentarDto> Handle(ConsumoAlimentarByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
