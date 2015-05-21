using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class OwsAdapterCustomException : BaseException
    {
        public OwsAdapterCustomException()
            : base()
        {
            //Add Implementation
        }

        public OwsAdapterCustomException(string message)
            : base(message)
        {
            //Add Implementation
        }

        public OwsAdapterCustomException(string message, Exception inner)
            : base(message, inner)
        {
            //Add Implementation
        }

        protected OwsAdapterCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //Add Implementation
        }
    }
}
