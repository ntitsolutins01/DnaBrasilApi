using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Events;
public class TipoLaudosCreatedEvent : BaseEvent
{
    public TipoLaudosCreatedEvent(TipoLaudo laudo)
    {
        Laudo = laudo;
    }

    public TipoLaudo Laudo { get; }
}
