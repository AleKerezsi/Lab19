using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptii
{
    public class CursNotFoundException : Exception
    {
        public CursNotFoundException()
        {
        }

        public CursNotFoundException(string? message) : base(message)
        {
        }

        public CursNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CursNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
