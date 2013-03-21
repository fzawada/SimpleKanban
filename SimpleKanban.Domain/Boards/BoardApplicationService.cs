using SimpleKanban.Domain.Boards.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKanban.Domain.Boards
{
    public class BoardApplicationService
    {
        public BoardApplicationService()
        {

        }

        private void Update(Action<Board> action)
        {
        }

        public void When(CreateBoard cmd)
        {
            Update(x => x.Create(cmd.BoardId, cmd.Name));
        }

        public void Execute(ICommand cmd)
        {
            InvokeHelpers.InvokeCommand(this, cmd);
        }
    }
}
