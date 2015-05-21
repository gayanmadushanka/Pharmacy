
namespace Ccom.Common.DomainObjects
{
    public interface IEmailEntity
    {
        string ToEmailAddress { get; set; }

        string TemplateName { get; set; }

        string Subject { get; set; }
    }
}
