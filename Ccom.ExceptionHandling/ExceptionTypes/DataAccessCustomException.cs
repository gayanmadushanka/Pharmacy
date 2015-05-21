using System;
using System.Runtime.Serialization;

namespace Ccom.ExceptionHandling.ExceptionTypes
{
    public class DataAccessCustomException : BaseException
    {
        public DataAccessCustomException()
            : base()
        {
            //Add Implementation
        }

        public DataAccessCustomException(string message)
            : base(message)
        {
            //Add Implementation
        }

        public DataAccessCustomException(string message, Exception inner)
            : base(message, inner)
        {
            //Add Implementation
        }

        protected DataAccessCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //Add Implementation
        }
    }
}
