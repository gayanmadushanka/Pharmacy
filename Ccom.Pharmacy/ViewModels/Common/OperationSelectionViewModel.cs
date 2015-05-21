using Ccom.Common.Utils;
using Ccom.Pharmacy.Delegates;
using System;
using System.Windows.Input;

namespace Ccom.Pharmacy.ViewModels
{
    public class OperationSelectionViewModel : INPCBase
    {
        public ICommand CheckInBtnClickedCommand { get; private set; }
        public ICommand CheckOutBtnClickedCommand { get; private set; }
        public ICommand ReservationBtnClickedCommand { get; private set; }

        public OperationSelectionViewModel()
        {
            CheckInBtnClickedCommand = new DelegateCommand<object, object>(ExecuteCheckInBtnClickedCommand);
            CheckOutBtnClickedCommand = new DelegateCommand<object, object>(ExecuteCheckOutBtnClickedCommand);
            ReservationBtnClickedCommand = new DelegateCommand<object, object>(ExecuteReservationBtnClickedCommand);
        }

        private static void ExecuteCheckInBtnClickedCommand(object parameter)
        {
            //FetchBookingOptionView operation = new FetchBookingOptionView();
            //NavigationManager.AddView(operation);
            //NavigationManager.ViewHomeButton();
        }

        private static void ExecuteCheckOutBtnClickedCommand(object parameter)
        {
            try
            {
                ////int a = 1;
                ////int b = 0;
                ////int i = a / b;

                //// Create a Dictionary of extended properties
                //Dictionary<string, object> exProperties = new Dictionary<string, object>();
                //exProperties.Add("Extra Information", "Some Special Value");
                //// Create a LogEntry using the constructor parameters. 
                //LogEntry entry1 = new LogEntry("LogEntry with category, priority, event ID, severity, and title.", "General", 8, 9006, TraceEventType.Error, "Logging Block Examples", exProperties);
                //Logger.Write(entry1);

                //CheckOutSelectionView operation = new CheckOutSelectionView();
                //NavigationManager.AddView(operation);
                //NavigationManager.ViewHomeButton();
            }
            catch (Exception ex)
            {
                //UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private static void ExecuteReservationBtnClickedCommand(object parameter)
        {
            //IOperation operation = new MakeReservationView(ContentPanel, KioskResource.Reservation);
            //ContentPanel.OpenView(operation);

            //IOSGuest guest = new IOSGuest();
            //guest.FirstName = "Gayan";
            //guest.LastName = "Madushanka";
            //guest.AddressList = new List<IOSAddress> { new IOSAddress { AddressLine = new[] { "apura", "MArket" } } };
            //guest.EmailList = new List<IOSEmail> { new IOSEmail { Email = "ga@a.com" } };
            //guest.GovernmentId.DocumentNumber = "191";
            //guest.PhoneList = new List<IOSPhone> { new IOSPhone { PhoneNumber = "0716554338" } };

            //IOSHotelReservation hotelReservation = new IOSHotelReservation();
            //hotelReservation.UniqueIdList = new List<IOSUniqueId> { new IOSUniqueId { Value = "11010" } };

            //IOSRoomStay roomStay = new IOSRoomStay();
            //roomStay.TimeSpan.StartDate = DateTime.Now;
            //roomStay.TimeSpan.EndDate = DateTime.Now;
            //roomStay.TimeSpan.Nights = 3;
            //roomStay.RoomTypeList = new List<IOSRoomType>();
            //roomStay.RoomTypeList.Add(new IOSRoomType { RoomTypeCode = "DX", RoomNumber = new[] { "1111" } });
            //roomStay.GuestCount.AdultCount = 2;
            //roomStay.GuestCount.ChildCount = 2;
            //hotelReservation.RoomStays.Add(roomStay);

            //PdfGeneratorTestNew pdfGenerator = new PdfGeneratorTestNew(new InkCanvas(), guest, null);
            //pdfGenerator.GenaratePdfFile();


            //GuestDetailView operation = new GuestDetailView(null, null, false);
            //GuestDetailViewModel guestDetailViewModel = operation.DataContext as GuestDetailViewModel;
            //if (guestDetailViewModel != null)
            //{

            //}
            //NavigationManager.AddView(operation);

            ////var forgotPassword = new ForgotPassword
            ////{
            ////    Name = "Gayan",
            ////    Password = "11211",
            ////    Url = "http://localhost:3641"
            ////};

            ////EmailEntity emailEntity = new EmailEntity
            ////{
            ////    Subject = "Your Kiosk Account Password",
            ////    TemplateName = "\\ForgotPasswordMailTemplate\\ForgotPasswordMailTemplate.cshtml",
            ////    ToEmailAddress = "gayanmadushanka2@gmail.com"
            ////};

            ////EmailUtill.SendAcyncEmail(forgotPassword, emailEntity);

            ////////string Namespace = "http://schemas.microsoft.com/2004/06/E2ETraceEvent";

            //////////Microsoft.Practices.EnterpriseLibrary.Logging.XmlLogEntry.

            //////////XmlTraceListenerData xml = XmlSerializerUtil.DeSerializeXmlToObject<XmlTraceListenerData>(@"C:\KioskLog\xml.log");
            ////////XmlNode xml = XmlSerializerUtil.DeSerializeXmlToObject<XmlNode>(@"C:\KioskLog\xml.log", Namespace, StaticDataManager.GetXmlRootAttribute("E2ETraceEvent", Namespace));

            // Open config file
            //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            //fileMap.ExeConfigFilename = @"IOS.HMS.KIOSK.UI.exe.config";

            //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            //// Get EL log settings
            //LoggingSettings log = config.GetSection("loggingConfiguration") as LoggingSettings;

            //// Get TraceListener info
            //foreach (TraceListenerData listener in log.TraceListeners)
            //{
            //    // Check for listener types you care about
            //    if (listener is RollingFlatFileTraceListenerData)
            //    {
            //        RollingFlatFileTraceListenerData data = listener as RollingFlatFileTraceListenerData;
            //        Console.WriteLine(string.Format("Found RollingFlatFileLIstener with Name={0}, FileName={1}, Header={2}, Footer={3}, RollSizeKB={4}, TimeStampPattern={5},RollFileExistsBehavior={6}, RollInterval={7}, TraceOutputOptions={8}, Formatter={9}, Filter={10}",
            //            data.Name, data.FileName, data.Header, data.Footer, data.RollSizeKB,
            //            data.TimeStampPattern, data.RollFileExistsBehavior, data.RollInterval,
            //            data.TraceOutputOptions, data.Formatter, data.Filter));
            //    }
            //    else // other trace listener types e.g. FlatFileTraceListenerData 
            //    {
            //    }
            //}
        }
    }
}
