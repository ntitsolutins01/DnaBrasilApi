using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Events;
public class SeriesCreatedEvent : BaseEvent
{
    public SeriesCreatedEvent(Serie serie)
    {
        Serie = serie;
    }
    
    public Serie Serie { get; }
}
