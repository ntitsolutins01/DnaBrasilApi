using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudos;

namespace DnaBrasil.Application.Series.Querries;

public record GetSeriesQuery : IRequest<SeriesVm>;

public class GetSeriesQueryHandler : IRequestHandler<GetSeriesQuery, SeriesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SeriesVm> Handle(GetSeriesQuery request, CancellationToken cancellationToken)
    {
        return new SeriesVm
        {
            Lists = await _context.Series
                .AsNoTracking()
                .ProjectTo<SeriesDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken)
        };
    }
}
