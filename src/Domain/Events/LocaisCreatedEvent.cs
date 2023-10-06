using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Events;
public class LocaisCreatedEvent : BaseEvent
{
    public LocaisCreatedEvent(Local local)
    {
        Local = local;
    }

    public Local Local { get; }
}
