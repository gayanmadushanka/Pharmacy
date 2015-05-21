using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class CommonCustomException : BaseException
    {
        public CommonCustomException()
            : base()
        {
            // Add implementation (if required)
        }

        public CommonCustomException(string message)
            : base(message)
        {
            // Add Implementation (if required)
        }

        public CommonCustomException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation (if required)
        }

        protected CommonCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }
    }
}
