using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptii
{
    public class DuplicatException : Exception
    {
        public DuplicatException()
        {
        }

        public DuplicatException(string? message) : base(message)
        {
        }

        public DuplicatException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
