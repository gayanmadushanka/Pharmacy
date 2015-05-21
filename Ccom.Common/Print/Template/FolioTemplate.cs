using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using Ccom.Common.Print.DomainObjects;
using Ccom.Pharmacy.Core.DomainObjects;

namespace Ccom.Common.Print.Template
{
    class FolioTemplate : IPrintTemplate
    {
        private static IOSInvoice _folioDetails;

        private static readonly Font Hedder6 = new Font("Resources/Fonts/OpenSans-Light.ttf", 6); // 10
        private static readonly Font Content8 = new Font("Resources/Fonts/OpenSans-Light.ttf", 8); // 13

        private static readonly StringFormat CenterSf = new StringFormat();
        private static readonly StringFormat FarSf = new StringFormat();
        private static readonly StringFormat NearSf = new StringFormat();

        private static readonly Pen Pen = new Pen(Brushes.Black);

        private static int XQ0 = 25;
        private static int XQ4 = 825;

        public FolioTemplate(IOSInvoice templateObject)
        {
            _folioDetails = templateObject;
            CenterSf.Alignment = StringAlignment.Center;
            FarSf.Alignment = StringAlignment.Far;
            NearSf.Alignment = StringAlignment.Near;
        }

        public int SetHeader(PrintPageEventArgs e, int y)
        {
            e.Graphics.DrawString("Trevor Eden", Hedder6, Brushes.Black, 100, y = 30 + 15, NearSf);
            e.Graphics.DrawString("Unit 1/4B Herries Street", Hedder6, Brushes.Black, 100, y = y + 15, NearSf);
            e.Graphics.DrawString("Toowoomba, QLD 4350", Hedder6, Brushes.Black, 100, y = y + 15, NearSf);
            e.Graphics.DrawString("Australia", Hedder6, Brushes.Black, 100, y = y + 15, NearSf);

            Image image = Image.FromFile(@"D:\WorkDir_IOneSoft\HMS.KIOSK\IOS.HMS.KIOSK\IOS.Common\Print\Resources\Images\Folio1.bmp");
            e.Graphics.DrawImage(image, 600, 15);

            int y1 = 0;
            int x1 = 650;
            e.Graphics.DrawString("66 Queen Street Mall, Brisbane QLD 4000", Hedder6, Brushes.Black, x1, y1 = y1 + 135, CenterSf);
            e.Graphics.DrawString("Telephone: 61 7 3222 3222", Hedder6, Brushes.Black, x1, y1 = y1 + 15, CenterSf);
            e.Graphics.DrawString("Facsimile: 61 7 3221 9389", Hedder6, Brushes.Black, x1, y1 = y1 + 15, CenterSf);
            e.Graphics.DrawString("ABN:27 161 379 880", Hedder6, Brushes.Black, x1, y1 = y1 + 15, CenterSf);
            e.Graphics.DrawString("Email: reservations.lennons@chifleyhotels.com", Hedder6, Brushes.Black, x1, y1 = y1 + 15, CenterSf);
            e.Graphics.DrawString("Book online at: www.silverneedlehotels.com.au", Hedder6, Brushes.Black, x1, y1 = y1 + 15, CenterSf);
            e.Graphics.DrawString("Central Reservations: 1300 650 464", Hedder6, Brushes.Black, x1, y1 = y1 + 15, CenterSf);

            e.Graphics.DrawString("Membership No.", Hedder6, Brushes.Black, 50, 210, NearSf);
            e.Graphics.DrawString("DUPLICATE TAX INVOICE", Hedder6, Brushes.Black, 50, 225, NearSf);

            e.Graphics.DrawString("Page   1 of 1", Hedder6, Brushes.Black, 200, 210, NearSf);
            e.Graphics.DrawString("Printed    16-JUL-13 09:48 AM", Hedder6, Brushes.Black, 200, 225, NearSf);

            return y + 120;
        }

        public int SetBody(PrintPageEventArgs e, int y)
        {
            GraphicsPath addRectangle1 = AddRectangle(XQ0, 250, 800, 20);
            e.Graphics.FillPath(Brushes.Gray, addRectangle1);
            e.Graphics.DrawPath(Pens.Black, addRectangle1);

            GraphicsPath addRectangle2 = AddRectangle(XQ0, 300, 800, 20);
            e.Graphics.FillPath(Brushes.Gray, addRectangle2);
            e.Graphics.DrawPath(Pens.Black, addRectangle2);

            e.Graphics.DrawString("Folio/Inv. No", Hedder6, Brushes.Black, XQ0 + 15, 255, NearSf);
            e.Graphics.DrawString("Arrival", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 255, NearSf);
            e.Graphics.DrawString("Departure", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 255, NearSf);
            e.Graphics.DrawString("Room", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 255, NearSf);
            e.Graphics.DrawString("Guests", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 255, NearSf);
            e.Graphics.DrawString("Reference/Group", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 255, NearSf);

            e.Graphics.DrawString(_folioDetails.BillNumber.Value, Hedder6, Brushes.Black, XQ0 + 15, 270, NearSf);
            e.Graphics.DrawString("Arrival", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 270, NearSf);
            e.Graphics.DrawString("Departure", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 270, NearSf);
            e.Graphics.DrawString("Room", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 270, NearSf);
            e.Graphics.DrawString("Guests", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 270, NearSf);
            e.Graphics.DrawString("Reference/Group", Hedder6, Brushes.Black, XQ0 = XQ0 + 70, 270, NearSf);



            XQ0 = 25;
            e.Graphics.DrawString("Date", Hedder6, Brushes.Black, XQ0 + 15, 305, NearSf);
            e.Graphics.DrawString("Description", Hedder6, Brushes.Black, XQ0 = XQ0 + 170, 305, NearSf);
            e.Graphics.DrawString("Reference", Hedder6, Brushes.Black, XQ0 = XQ0 + 170, 305, NearSf);
            e.Graphics.DrawString("Charges", Hedder6, Brushes.Black, XQ0 = XQ0 + 170, 305, NearSf);
            e.Graphics.DrawString("Credits", Hedder6, Brushes.Black, XQ0 = XQ0 + 170, 305, NearSf);

            XQ0 = 45;
            y = 335;
            foreach (IOSInvoiceItem invoiceItem in _folioDetails.InvoiceItemList)
            {
                e.Graphics.DrawString(invoiceItem.Date.ToString(CultureInfo.InvariantCulture), Content8, Brushes.Black, XQ0 + 15, y, NearSf);
                e.Graphics.DrawString(invoiceItem.Description, Content8, Brushes.Black, XQ0 = XQ0 + 170, y, NearSf);
                e.Graphics.DrawString(invoiceItem.Reference, Content8, Brushes.Black, XQ0 = XQ0 + 170, y, NearSf);
                e.Graphics.DrawString(invoiceItem.Amount.Value.ToString(CultureInfo.InvariantCulture), Content8, Brushes.Black, XQ0 = XQ0 + 170, y, NearSf);
                e.Graphics.DrawString(invoiceItem.Supplement, Content8, Brushes.Black, XQ0 = XQ0 + 170, y, NearSf);
                XQ0 = 45;
                y = y + 15;
            }

            e.Graphics.DrawLine(Pen, new PointF(45, y + 15), new PointF(XQ4, y + 15));

            e.Graphics.DrawString("Total net of Tax", Hedder6, Brushes.Black, 400, y = y + 30, NearSf);

            e.Graphics.DrawString("GST 10%", Hedder6, Brushes.Black, 400, y = y + 15, NearSf);
            e.Graphics.DrawString("Total including Tax", Hedder6, Brushes.Black, 400, y = y + 15, NearSf);
            e.Graphics.DrawString("* Indicates non-taxable supply", Hedder6, Brushes.Black, 400, y = y + 15, NearSf);
            e.Graphics.DrawString("Balance Due", Hedder6, Brushes.Black, 400, y = y + 15, NearSf);

            return y + 75;
        }



        public int SetFooter(PrintPageEventArgs e, int y)
        {
            y = 805;
            e.Graphics.DrawLine(new Pen(Brushes.Black), new PointF(25, y), new PointF(825, y));

            e.Graphics.DrawPath(new Pen(Color.Black, 0.5F), AddRectangle(25, 820, 300, 100));

            e.Graphics.DrawLine(new Pen(Brushes.Black), new PointF(25, y + 30), new PointF(325, y + 30));
            e.Graphics.DrawLine(new Pen(Brushes.Black), new PointF(45, y + 80), new PointF(315, y + 80));

            e.Graphics.DrawLine(new Pen(Brushes.Black), new PointF(325, y + 15), new PointF(325, y + 90));

            e.Graphics.DrawString("Direct Payment to", Hedder6, Brushes.Black, 45, 820, NearSf);
            e.Graphics.DrawString("Signature", Hedder6, Brushes.Black, 45, 835, NearSf);

            int y2 = 905;
            e.Graphics.DrawString("I AGREE THAT I AM PERSONALLY LIABLE FOR THE PAYMENT OF THE ABOVE ACCOUNT AND IF", Hedder6, Brushes.Black, 15, y2, NearSf);
            e.Graphics.DrawString("THE PERSON, COMPANY OR ASSOCIATION INDICATED BY ME AS BEING RESPONSIBLE FOR THE", Hedder6, Brushes.Black, 15, y2 = y2 + 15, NearSf);
            e.Graphics.DrawString("PAYMENT OF THE SAME DOES NOT DO SO, THAT MY LIABILITY FOR SUCH PAYMENT SHALL BE", Hedder6, Brushes.Black, 15, y2 = y2 + 15, NearSf);
            e.Graphics.DrawString("JOINT AND SEVERAL WITH SUCH PERSON, COMPANY OR ASSOCIATION.", Hedder6, Brushes.Black, 15, y2 = y2 + 15, NearSf);
            e.Graphics.DrawString("UNLESS OTHERWISE NOTIFIED BY YOU, YOUR CREDIT CARD DETAILS WILL BE RETAINED IN", Hedder6, Brushes.Black, 15, y2 = y2 + 15, NearSf);
            e.Graphics.DrawString("YOUR SILVERNEEDLE HOTEL GROUP GUEST PROFILE SO THAT WE MAY PROVIDE YOU WITH A", Hedder6, Brushes.Black, 15, y2 = y2 + 15, NearSf);
            e.Graphics.DrawString("QUICKER CHECK IN FOR FUTURE STAYS WITH US.", Hedder6, Brushes.Black, 15, y2 = y2 + 15, NearSf);


            e.Graphics.DrawString("SN HOTEL MANAGEMENT BRISBANE PTY. LTD.", Content8, Brushes.Black, 625, 820, CenterSf);
            e.Graphics.DrawString("ABN 27 161 379 880", Content8, Brushes.Black, 625, 835, CenterSf);

            Image image = Image.FromFile(@"D:\WorkDir_IOneSoft\HMS.KIOSK\IOS.HMS.KIOSK\IOS.Common\Print\Resources\Images\FolioFooter.bmp");
            e.Graphics.DrawImage(image, 400, 850);
            return y + 40;
        }

        private GraphicsPath AddRectangle(int x, int y, int width, int height)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(new Rectangle(x, y, width, height));
            return graphicsPath;
        }
    }
}
