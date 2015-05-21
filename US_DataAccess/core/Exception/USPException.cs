
namespace US_DataAccess.core.Exception
{
    public class USPException : System.Exception
    {
        private string _errorMessage = string.Empty;

        public void logg(string loger)
        {
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }

        public override string Message
        {
            get
            {
                return _errorMessage;
            }
        }
    }
}
