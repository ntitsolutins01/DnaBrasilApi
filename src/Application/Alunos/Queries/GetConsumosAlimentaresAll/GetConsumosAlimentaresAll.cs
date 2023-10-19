using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Queries.GetConsumosAlimentaresAll;

public record GetConsumosAlimentaresAllQuery : IRequest<AlunoDto>
{
}

public class GetConsumosAlimentaresAllQueryValidator : AbstractValidator<GetConsumosAlimentaresAllQuery>
{
    public GetConsumosAlimentaresAllQueryValidator()
    {
    }
}

public class GetConsumosAlimentaresAllQueryHandler : IRequestHandler<GetConsumosAlimentaresAllQuery, AlunoDto>
{
    private readonly IApplicationDbContext _context;

    public GetConsumosAlimentaresAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<AlunoDto> Handle(GetConsumosAlimentaresAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
