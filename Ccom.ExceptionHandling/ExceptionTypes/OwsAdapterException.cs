using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class OwsAdapterException : BaseException
    {
        public OwsAdapterException()
            : base()
        {
            // Add implementation (if required)
        }

        public OwsAdapterException(string message)
            : base(message)
        {
            // Add implemenation (if required)
        }

        public OwsAdapterException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation
        }

        protected OwsAdapterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //Add implemenation
        }
    }
}
