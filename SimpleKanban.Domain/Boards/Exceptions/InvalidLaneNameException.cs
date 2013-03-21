using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKanban.Domain.Boards.Exceptions
{
    [Serializable]
    public class InvalidLaneNameException : Exception
    {
        public InvalidLaneNameException() { }
        public InvalidLaneNameException(string message) : base(message) { }
        public InvalidLaneNameException(string message, Exception inner) : base(message, inner) { }
        protected InvalidLaneNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
