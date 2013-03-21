using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKanban.Domain
{
    public interface IEventStore
    {
        EventStream LoadEventStream(Guid id);
        void AppendEventsToStream(IIdentity id, long version, ICollection<IEvent> events);
    }
}
