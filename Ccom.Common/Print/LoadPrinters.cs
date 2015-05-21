using System.Management;

namespace Ccom.Common.Print
{
    public class LoadPrinters
    {
        public static void LoadPrinter()
        {
            //We use the ObjectQuery to get the list of configured printers
            ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_Printer");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(objectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            //If at least one printer is found, we add it to a specific list and enable the Print button.
            if (managementObjectCollection.Count > 0)
            {
                //For each printer found, we put it either in the local or network combobox, accordingly.
                foreach (ManagementObject managementObject in managementObjectCollection)
                {
                    //It's a network printer.
                    if ((bool)managementObject["Network"])
                    {

                    }
                        //It's a local printer.
                    else
                    {

                    }
                    //If the printer is found to be the default one, we select it.
                    if ((bool)managementObject["Default"])
                    {

                    }
                }
            }
        }
    }
}