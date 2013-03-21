using System;

namespace SimpleKanban.Domain.Boards.Commands
{
    public class CreateBoard
    {
        public Guid BoardId { get; set; }
        public string Name { get; set; }

        public CreateBoard(Guid boardId, string name)
        {
            BoardId = boardId;
            Name = name;
        }
    }
}
