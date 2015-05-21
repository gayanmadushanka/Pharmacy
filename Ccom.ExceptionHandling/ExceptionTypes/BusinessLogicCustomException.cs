using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class BusinessLogicCustomException : BaseException
    {
        public BusinessLogicCustomException()
            : base()
        {
            // Add implementation (if required)
        }

        public BusinessLogicCustomException(string message)
            : base(message)
        {
            // Add Implementation (if required)
        }

        public BusinessLogicCustomException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation (if required)
        }

        protected BusinessLogicCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }
    }
}
