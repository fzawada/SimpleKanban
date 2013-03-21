using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKanban.Domain.Boards.Events
{
    public class LaneCreated : Event
    {
        public Guid LaneId { get; set; }
        public string Name { get; set; }

        public LaneCreated(Guid laneId, string name)
        {
            LaneId = laneId;
            Name = name;
        }
    }
}
