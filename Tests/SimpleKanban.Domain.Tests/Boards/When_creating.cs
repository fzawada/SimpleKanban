using System;
using System.Linq;
using Simple.Testing.ClientFramework;
using SimpleKanban.Domain.Boards;
using SimpleKanban.Domain.Boards.Events;
using SimpleKanban.Domain.Boards.Exceptions;

namespace SimpleKanban.Domain.Tests.Boards
{
    public class When_creating
    {
        public Specification Should_be_able_to_create_new_board()
        {
            var id = Guid.NewGuid();
            var name = "Sample board";

            return new ActionSpecification<Board>
                {
                    On = () => new Board(),
                    When = board => board.Create(id, name),
                    Expect =
                        {
                            board => board.GetChanges().Single().Equals(new BoardCreated(id, name))
                        }
                };
        }

        public Specification Should_throw_if_the_name_is_empty()
        {
            var name = "  ";
            return new FailingSpecification<Board, InvalidBoardNameException>
                {
                    On = () => new Board(),
                    When = board => board.Create(Guid.NewGuid(), name),
                };
        }
    }
}