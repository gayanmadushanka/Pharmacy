using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class PassThroughException : BaseException
    {
        public PassThroughException()
            : base()
        {
            // Add implementation (if required)
        }

        public PassThroughException(string message)
            : base(message)
        {
            // Add implemenation (if required)
        }

        public PassThroughException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation
        }

        protected PassThroughException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //Add implemenation
        }
    }
}
