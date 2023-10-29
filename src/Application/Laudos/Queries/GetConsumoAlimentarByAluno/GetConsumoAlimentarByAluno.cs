using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Laudos.Queries.ConsumoAlimentarByAluno;

namespace DnaBrasil.Application.Laudos.Queries.GetConsumoAlimentarByAluno;

public record GetConsumoAlimentarByAlunoQuery : IRequest<ConsumoAlimentarDto>
{
}

public class GetConsumoAlimentarByAlunoQueryValidator : AbstractValidator<GetConsumoAlimentarByAlunoQuery>
{
    public GetConsumoAlimentarByAlunoQueryValidator()
    {
    }
}

public class GetConsumoAlimentarByAlunoQueryHandler : IRequestHandler<GetConsumoAlimentarByAlunoQuery, ConsumoAlimentarDto>
{
    private readonly IApplicationDbContext _context;

    public GetConsumoAlimentarByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<ConsumoAlimentarDto> Handle(GetConsumoAlimentarByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
