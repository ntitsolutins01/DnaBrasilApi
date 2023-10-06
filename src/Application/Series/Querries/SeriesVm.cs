using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudos;

namespace DnaBrasil.Application.Series.Querries;
public class SeriesVm
{
    public IReadOnlyCollection<SerieDto> Lists { get; init; } = Array.Empty<SerieDto>();
}
