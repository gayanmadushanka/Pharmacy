namespace Ccom.Common.Email
{
    class EmailConfigurations
    {
        public string ServerName { get; set; }

        public string SenderAddress { get; set; }

        public string Password { get; set; }

        public string ReceiverAddress { get; set; }

        public string TemplateFolderPath { get; set; }

        public EmailConfigurations()
        {
            //AttachmentFileName = string.Empty;
            //DestinationEmail = string.Empty;
            //IsDocumentAttached = false;
            //SubjectTextFilePath = string.Empty;
            //FooterTextFilePath = string.Empty;
            //HeaderTextFilePath = string.Empty;
            //BccAddress = string.Empty;
            //CcAddress = string.Empty;
            TemplateFolderPath = string.Empty;
            ReceiverAddress = string.Empty;
            Password = string.Empty;
            SenderAddress = string.Empty;
            ServerName = string.Empty;
        }

        //public string CcAddress { get; set; }
        //public string BccAddress { get; set; }
        //public string HeaderTextFilePath { get; set; }
        //public string FooterTextFilePath { get; set; }
        //public string SubjectTextFilePath { get; set; }
        //public bool IsDocumentAttached { get; set; }
        //public string DestinationEmail { get; set; }
        //public string AttachmentFileName { get; set; }
    }
}
