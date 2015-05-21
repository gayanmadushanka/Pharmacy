using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class DataAccessException : BaseException
    {
        public DataAccessException()
            : base()
        {
            // Add implementation (if required)
        }

        public DataAccessException(string message)
            : base(message)
        {
            // Add implemenation (if required)
        }

        public DataAccessException(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation
        }

        protected DataAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //Add implemenation
        }

    }
}
