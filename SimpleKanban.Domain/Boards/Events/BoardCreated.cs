using System;

namespace SimpleKanban.Domain.Boards.Events
{
    public class BoardCreated : Event
    {
        public Guid BoardId { get; set; }
        public string Name { get; set; }

        public BoardCreated(Guid boardId, string name)
        {
            BoardId = boardId;
            Name = name;
        }
    }
}
