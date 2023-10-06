using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudos;

namespace DnaBrasil.Application.Locais.Queries;

public record GetLocaisQuery : IRequest<LocaisVm>;
public class GetLocaisQueryHandler : IRequestHandler<GetLocaisQuery, LocaisVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLocaisQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<LocaisVm> Handle(GetLocaisQuery request, CancellationToken cancellationToken)
    {
        return new LocaisVm
        {
            Lists = await _context.Series
                .AsNoTracking()
                .ProjectTo<LocaisDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken)
        };
    }
}
