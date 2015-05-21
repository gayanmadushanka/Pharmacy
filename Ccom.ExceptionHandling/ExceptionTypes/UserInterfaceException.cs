using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class UserInterfaceException : Exception
    {
        public UserInterfaceException()
            : base()
        {
            // Add implementation (if required)
        }

        public UserInterfaceException(string message)
            : base(message)
        {
            // Add implemenation (if required)
        }

        public UserInterfaceException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation
        }

        protected UserInterfaceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //Add implemenation
        }
    }
}
