﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptii
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException()
        {
        }

        public StudentNotFoundException(string? message) : base(message)
        {
        }

        public StudentNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StudentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
