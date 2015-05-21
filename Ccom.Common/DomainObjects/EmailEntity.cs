namespace Ccom.Common.DomainObjects
{
    public class EmailEntity : IEmailEntity
    {
        public string ToEmailAddress { get; set; }

        public string TemplateName { get; set; }

        public string Subject { get; set; }
    }
}
