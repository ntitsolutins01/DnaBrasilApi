using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Series.Querries;

namespace DnaBrasil.Application.Locais.Queries;
public class LocaisVm
{
    public IReadOnlyCollection<LocaisDto> Lists { get; init; } = Array.Empty<LocaisDto>();
}
