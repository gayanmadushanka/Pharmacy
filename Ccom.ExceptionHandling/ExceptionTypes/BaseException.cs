using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class BaseException : Exception
    {
        public BaseException()
            : base()
        {
            // Add implementation (if required)
        }

        public BaseException(string message)
            : base(message)
        {
            // Add implementation (if required)
        }

        public BaseException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation (if required)
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }
    }
}
