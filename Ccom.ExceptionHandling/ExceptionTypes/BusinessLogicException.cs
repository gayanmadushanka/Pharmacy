using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class BusinessLogicException : BaseException
    {
        public BusinessLogicException()
            : base()
        {
            // Add implementation (if required)
        }

        public BusinessLogicException(string message)
            : base(message)
        {
            // Add Implementation (if required)
        }

        public BusinessLogicException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation (if required)
        }

        protected BusinessLogicException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }
    }
}
