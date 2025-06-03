using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosByLocalidadeId;
//[Authorize]
public record GetNomeAlunosByLocalidadeIdQuery : IRequest<List<SelectListDto>>
{
    public required int LocalidadeId { get; init; }
}

public class GetNomeAlunosByLocalidadeIdQueryHandler : IRequestHandler<GetNomeAlunosByLocalidadeIdQuery, List<SelectListDto>>
{
    private readonly IApplicationDbContext _context;

    public GetNomeAlunosByLocalidadeIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SelectListDto>> Handle(GetNomeAlunosByLocalidadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .Where(x => x.Localidade!.Id == request.LocalidadeId && x.Convidado == false)                
            .OrderBy(t => t.Nome)
            .Select(s => new SelectListDto { Id = s.Id, Nome = s.Id + " - " + s.Nome.ToUpper() })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return result;
    }
}

