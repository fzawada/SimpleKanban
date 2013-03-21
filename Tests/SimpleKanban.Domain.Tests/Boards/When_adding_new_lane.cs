using System;
using System.Linq;
using Simple.Testing.ClientFramework;
using SimpleKanban.Domain.Boards;
using SimpleKanban.Domain.Boards.Events;
using SimpleKanban.Domain.Boards.Exceptions;

namespace SimpleKanban.Domain.Tests.Boards
{
    public class When_adding_new_lane
    {
        public Specification Should_be_able_to_create_new_lane()
        {
            var laneId = Guid.NewGuid();
            var laneName = "lane1";
            return new ActionSpecification<Board>()
            {
                On = () => CreateEmptyBoard(),
                When = board => board.AddLane(laneId, laneName),
                Expect = { board => board.GetChanges().Single().Equals(new LaneCreated(laneId, laneName)) }
            };
        }

        public Specification Should_throw_if_name_is_empty()
        {
            var laneName = "  ";
            return new FailingSpecification<Board, InvalidLaneNameException>()
            {
                On = () => CreateEmptyBoard(),
                When = board => board.AddLane(Guid.NewGuid(), laneName),
            };
        }

        public Board CreateEmptyBoard()
        {
            var board = new Board();
            board.Apply(new BoardCreated(Guid.NewGuid(), "asd"));
            return board;
        }
    }
}
