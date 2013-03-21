using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKanban.Domain.Boards.Exceptions
{
    [Serializable]
    public class InvalidBoardNameException : Exception
    {
        public InvalidBoardNameException() { }
        public InvalidBoardNameException(string message) : base(message) { }
        public InvalidBoardNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidBoardNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
