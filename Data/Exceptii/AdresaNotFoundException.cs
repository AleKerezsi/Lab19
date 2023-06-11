using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptii
{
    public class AdresaNotFoundException : Exception
    {
        public AdresaNotFoundException()
        {
        }

        public AdresaNotFoundException(string? message) : base(message)
        {
        }

        public AdresaNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AdresaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
