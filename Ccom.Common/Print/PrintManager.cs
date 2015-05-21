using System;
using System.Drawing.Printing;
using Ccom.Common.DomainObjects;
using Ccom.Common.Helpers;
using Ccom.Common.Print.DomainObjects;
using Ccom.Common.Print.Template;
using Ccom.Common.Utils;
using Ccom.Pharmacy.DAL.Entity;

namespace Ccom.Common.Print
{
    public class PrintManager
    {
        private readonly static Configuration Configeration = new Configuration();

        private static InvoiceEntity _invoice = new InvoiceEntity();

        static PrintManager()
        {
            GetValueFromConfiguration();
        }

        public PrintManager()
        {
            //LoadPrinters.LoadPrinter();
        }

        public void Print(InvoiceEntity invoice)
        {
            _invoice = invoice;

            PrintDocument printDocument = new PrintDocument();
            //if need to print by printer
            //printDocument.PrinterSettings.PrinterName = _printerName;

            //if print to pdf file
            printDocument.PrinterSettings.PrintToFile = true;
            //printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4 c", 826, 11690);

            StandardPrintController standardPrintController = new StandardPrintController();
            printDocument.PrintController = standardPrintController;
            printDocument.PrintPage += printDoc_PrintPage;
            if (printDocument.PrinterSettings.IsValid)
            {
                printDocument.Print();
            }
        }

        private static void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            try
            {
                PharmacyReceiptTemplate pharmacyReceiptTemplate = new PharmacyReceiptTemplate(Configeration, _invoice);
                int y1 = pharmacyReceiptTemplate.SetHeader(e, 0);
                int y2 = pharmacyReceiptTemplate.SetBody(e, y1);
                pharmacyReceiptTemplate.SetFooter(e, y2);
            }
            catch (Exception)
            {
            }
        }

        private static void GetValueFromConfiguration()
        {
            string configFilePath = (GetLocation.GetLocationPath()) + @"\Configuration.xml";
            ConfigurationItemList configurationItemList = XmlSerializerUtil.DeSerializeXmlToObject<ConfigurationItemList>(configFilePath);

            foreach (var item in configurationItemList.Configurations)
            {
                SetValueToConfiguration(item);
            }
        }

        private static void SetValueToConfiguration(ConfigurationItem item)
        {
            switch (item.Key)
            {
                case ConstantManager.Name:
                    Configeration.Name = item.Value;
                    break;
                case ConstantManager.Address:
                    Configeration.Address = item.Value;
                    break;
                case ConstantManager.ContactNo:
                    Configeration.ContactNo = item.Value;
                    return;
                case ConstantManager.Email:
                    Configeration.Email = item.Value;
                    break;
                case ConstantManager.PrinterName:
                    Configeration.PrinterName = item.Value;
                    return;
            }
        }
    }
}
