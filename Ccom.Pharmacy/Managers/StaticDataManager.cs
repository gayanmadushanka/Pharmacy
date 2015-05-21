using System.Xml.Serialization;

namespace Ccom.Pharmacy.Managers
{
    internal static class StaticDataManager
    {
        public static string ReportPath;
        public static string ImagePath;
        public static string LogPath;
        public static string UserName;
        public static string Password;

        public static PharmacyMainView Window;

        internal static XmlRootAttribute GetXmlRootAttribute(string elementName, string Namespace)
        {
            return new XmlRootAttribute
            {
                ElementName = elementName,
                Namespace = Namespace,
                IsNullable = true
            };
        }
    }
}
