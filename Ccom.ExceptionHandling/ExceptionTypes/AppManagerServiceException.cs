using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class AppManagerServiceException : BaseException
    {
        public AppManagerServiceException()
            : base()
        {
            // Add implementation (if required)
        }

        public AppManagerServiceException(string message)
            : base(message)
        {
            // Add Implementation (if required)
        }

        public AppManagerServiceException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation (if required)
        }

        protected AppManagerServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }
    }
}
