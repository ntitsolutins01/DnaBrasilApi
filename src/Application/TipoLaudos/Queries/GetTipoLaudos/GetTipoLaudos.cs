using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Common.Models;
using DnaBrasil.Application.Common.Security;
using DnaBrasil.Application.TodoLists.Queries.GetTodos;
using DnaBrasil.Domain.Enums;

namespace DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudos;


//[Authorize]
public record GetTipoLaudosQuery : IRequest<TipoLaudosVm>;

public class GetTipoLaudosQueryHandler : IRequestHandler<GetTipoLaudosQuery, TipoLaudosVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTipoLaudosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TipoLaudosVm> Handle(GetTipoLaudosQuery request, CancellationToken cancellationToken)
    {
        return new TipoLaudosVm
        {
            Lists = await _context.TipoLaudos
                .AsNoTracking()
                .ProjectTo<TipoLaudoDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken)
        };
    }
}
