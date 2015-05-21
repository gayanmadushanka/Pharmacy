using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class CommonException : BaseException
    {
        public CommonException()
            : base()
        {
            // Add implementation (if required)
        }

        public CommonException(string message)
            : base(message)
        {
            // Add Implementation (if required)
        }

        public CommonException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation (if required)
        }

        protected CommonException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }
    }
}
