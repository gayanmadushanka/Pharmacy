using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using Ccom.Common.Print.DomainObjects;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Common.Print.Template
{
    class PharmacyReceiptTemplate : IPrintTemplate
    {
        private static Configuration _configuration;
        private readonly InvoiceEntity _invoice;

        private static readonly StringFormat CenterSf = new StringFormat();
        private static readonly StringFormat FarSf = new StringFormat();
        private static readonly StringFormat NearSf = new StringFormat();

        private static readonly float[] DashValues = { 5, 3 };
        private static readonly float[] TableValues = { 145, 5, 20, 5, 30, 5, 40 };
        private static readonly Pen DashPen = new Pen(Brushes.Black);
        private static readonly Pen DashTablePen = new Pen(Brushes.Black);
        private static readonly Pen BlackPen = new Pen(Brushes.Black);

        private const int Xq0 = 20;
        private const int Xq4 = 275;

        public PharmacyReceiptTemplate(Configuration configuration, InvoiceEntity invoice)
        {
            _configuration = configuration;
            _invoice = invoice;
            DashPen.DashPattern = DashValues;
            DashTablePen.DashPattern = TableValues;
            CenterSf.Alignment = StringAlignment.Center;
            FarSf.Alignment = StringAlignment.Far;
            NearSf.Alignment = StringAlignment.Near;
        }

        public int SetHeader(PrintPageEventArgs e, int y)
        {
            e.Graphics.DrawString(_configuration.Name, FontManager.Hedder15, Brushes.Black, 150, 0, CenterSf);
            e.Graphics.DrawString(_configuration.Address, FontManager.Hedder6, Brushes.Black, 150, 22, CenterSf);
            e.Graphics.DrawString("Tel : " + _configuration.ContactNo, FontManager.Hedder6, Brushes.Black, 150, 32, CenterSf);
            e.Graphics.DrawString("Invoice No : " + _invoice.InvoiceNo, FontManager.Hedder6, Brushes.Black, 20, 42, NearSf);
            e.Graphics.DrawString("Date : " + _invoice.Date, FontManager.Hedder6, Brushes.Black, 275, 42, FarSf);
            return 55;
        }

        public int SetBody(PrintPageEventArgs e, int y)
        {
            e.Graphics.DrawLine(BlackPen, new PointF(Xq0, y), new PointF(Xq4, y));

            //e.Graphics.DrawLine(DashTablePen, new PointF(Xq0, y), new PointF(Xq4, y));
            //e.Graphics.DrawLine(DashTablePen, new PointF(Xq0, y + 1), new PointF(Xq4, y + 1));

            e.Graphics.DrawString("Item", FontManager.Content8, Brushes.Black, Xq0, y + 2);
            e.Graphics.DrawString("Qty", FontManager.Content8, Brushes.Black, Xq0 + 150, y + 2);
            e.Graphics.DrawString("Price", FontManager.Content8, Brushes.Black, Xq0 + 175, y + 2);
            e.Graphics.DrawString("Amount", FontManager.Content8, Brushes.Black, Xq0 + 215, y + 2);

            e.Graphics.DrawLine(BlackPen, new PointF(Xq0, y + 15), new PointF(Xq4, y + 15));

            //e.Graphics.DrawLine(DashTablePen, new PointF(Xq0, y + 15), new PointF(Xq4, y + 15));
            //e.Graphics.DrawLine(DashTablePen, new PointF(Xq0, y + 16), new PointF(Xq4, y + 16));

            int tempY = y + 20;

            foreach (var invoiceItem in _invoice.InvoiceItemEntities)
            {
                e.Graphics.DrawString(invoiceItem.Item.Name, FontManager.Content7, Brushes.Black, Xq0, tempY);
                e.Graphics.DrawString(invoiceItem.Quantity.ToString(CultureInfo.InvariantCulture), FontManager.Content8, Brushes.Black, Xq0 + 170, tempY, FarSf);
                e.Graphics.DrawString(invoiceItem.Item.UnitPrice.ToString(CultureInfo.InvariantCulture), FontManager.Content8, Brushes.Black, 225, tempY, FarSf);
                e.Graphics.DrawString((invoiceItem.Item.UnitPrice * invoiceItem.Quantity).ToString(CultureInfo.InvariantCulture), FontManager.Content8, Brushes.Black, Xq4, tempY, FarSf);
                tempY = tempY + 10;
            }

            tempY = tempY + 5;

            e.Graphics.DrawLine(BlackPen, new PointF(Xq0, tempY), new PointF(Xq4, tempY));

            //e.Graphics.DrawLine(DashTablePen, new PointF(Xq0, tempY), new PointF(Xq4, tempY));
            //e.Graphics.DrawLine(DashTablePen, new PointF(Xq0, tempY + 1), new PointF(Xq4, tempY + 1));
            e.Graphics.DrawString("Sub Amount", FontManager.Content8, Brushes.Black, 150, tempY + 5, NearSf);
            e.Graphics.DrawString(_invoice.SubAmount.ToString(CultureInfo.InvariantCulture), FontManager.Content8, Brushes.Black, Xq4, tempY + 5, FarSf);

            tempY = tempY + 10;
            e.Graphics.DrawString("Discount", FontManager.Content8, Brushes.Black, 150, tempY + 5, NearSf);
            e.Graphics.DrawString(_invoice.Discount.ToString(CultureInfo.InvariantCulture), FontManager.Content8, Brushes.Black, Xq4, tempY + 5, FarSf);

            tempY = tempY + 10;
            e.Graphics.DrawString("Total Amount", FontManager.Content8, Brushes.Black, 150, tempY + 5, NearSf);
            e.Graphics.DrawString(_invoice.TotalAmount.ToString(CultureInfo.InvariantCulture), FontManager.Content8, Brushes.Black, Xq4, tempY + 5, FarSf);

            tempY = tempY + 10;
            e.Graphics.DrawString("Cash", FontManager.Content8, Brushes.Black, 150, tempY + 5, NearSf);
            e.Graphics.DrawString(_invoice.Cash.ToString(CultureInfo.InvariantCulture), FontManager.Content8, Brushes.Black, Xq4, tempY + 5, FarSf);

            tempY = tempY + 10;
            e.Graphics.DrawString("Balance", FontManager.Content8, Brushes.Black, 150, tempY + 5, NearSf);
            e.Graphics.DrawString(_invoice.Balance.ToString(CultureInfo.InvariantCulture), FontManager.Content8, Brushes.Black, Xq4, tempY + 5, FarSf);

            //tempY = tempY + 5;
            //e.Graphics.DrawLine(DashTablePen, new PointF(Xq0, tempY), new PointF(Xq4, tempY));
            //e.Graphics.DrawLine(DashTablePen, new PointF(Xq0, tempY + 1), new PointF(Xq4, tempY + 1));
            return tempY + 20;
        }

        public int SetFooter(PrintPageEventArgs e, int y)
        {
            e.Graphics.DrawLine(DashPen, new PointF(Xq0, y), new PointF(Xq4, y));
            e.Graphics.DrawString("Thank You !", FontManager.Content8, Brushes.Black, 150, y + 5, CenterSf);
            e.Graphics.DrawLine(DashPen, new PointF(Xq0, y + 20), new PointF(Xq4, y + 20));
            return y + 40;
        }
    }
}
