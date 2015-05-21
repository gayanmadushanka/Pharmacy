using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    [Serializable]
    public class UserAlreadyLoggedInException : Exception
    {
        public UserAlreadyLoggedInException()
        {
            // Add implementation (if required)
        }

        public UserAlreadyLoggedInException(string message)
            : base(message)
        {
            // Add implementation (if required)
        }

        public UserAlreadyLoggedInException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation (if required)
        }

        protected UserAlreadyLoggedInException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }
    }
}
