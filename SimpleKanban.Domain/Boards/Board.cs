using SimpleKanban.Domain.Boards.Events;
using SimpleKanban.Domain.Boards.Exceptions;
using System;

namespace SimpleKanban.Domain.Boards
{
    public class Board : AggregateBase
    {
        private Guid Id { get; set; }
        
        public void Create(Guid id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidBoardNameException(string.Format("Board name '{0}' is not valid", name));
            }

            Apply(new BoardCreated(id, name));
        }

        public void AddLane(Guid id, string laneName)
        {
            if (string.IsNullOrWhiteSpace(laneName))
            {
                throw new InvalidLaneNameException(string.Format("Lane name '{0}' is not valid", laneName));
            }
            Apply(new LaneCreated(id, laneName));
        }

        private void Mutate(BoardCreated ev)
        {
            Id = ev.BoardId;
        }
    }
}