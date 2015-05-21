using System.Drawing.Printing;

namespace Ccom.Common.Print.DomainObjects
{
    public interface IPrintTemplate
    {
        int SetHeader(PrintPageEventArgs e, int y);
        int SetBody(PrintPageEventArgs e, int y);
        int SetFooter(PrintPageEventArgs e, int y);
    }
}
