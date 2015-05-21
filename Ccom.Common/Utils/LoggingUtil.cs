using System;
using System.Globalization;
using System.IO;
using Ccom.Common.Helpers;

namespace Ccom.Common.Utils
{
    public static class LoggingUtil
    {
        public static void XmlLog(string message, string type, string transactionId, string logPath)
        {
            try
            {
                var folderName = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) + GetFormattedString(DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)) + GetFormattedString(DateTime.Now.Day.ToString(CultureInfo.InvariantCulture));

                if (logPath == string.Empty)
                    logPath = ConstantManager.DefaultLogPath;

                var folderPath = logPath + @"\" + folderName + @"\";
                var fileName = transactionId + "_" + type + ConstantManager.XmlExtention;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                File.AppendAllText(folderPath + fileName, message + Environment.NewLine);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetFormattedString(string value)
        {
            if (value.Length < 2)
            {
                value = "0" + value;
            }
            return value;
        }

        public static void TextLog(string message, string logPath)
        {
            try
            {
                var folderName = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) + GetFormattedString(DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)) + GetFormattedString(DateTime.Now.Day.ToString(CultureInfo.InvariantCulture));

                if (logPath == "")
                    logPath = ConstantManager.DefaultLogPath;

                var folderPath = logPath + folderName + @"\";
                var fileName = DateTime.Now + ConstantManager.TextExtention;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                File.AppendAllText(folderPath + fileName, message + Environment.NewLine);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //StringBuilder folderName = new StringBuilder();
        //folderName.Append(GetFormattedString(DateTime.Now.Year.ToString(CultureInfo.InvariantCulture)));
        //folderName.Append(GetFormattedString(DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)));
        //folderName.Append(GetFormattedString(DateTime.Now.Day.ToString(CultureInfo.InvariantCulture)));

        //if (logPath == string.Empty)
        //    logPath = ConstantManager.DefaultLogPath;

        //StringBuilder folderPath = new StringBuilder();
        //folderPath.Append(logPath);
        //folderPath.Append(folderName);
        //folderPath.Append(@"\");

        //StringBuilder fileName = new StringBuilder();
        //fileName.Append(transactionId);
        //fileName.Append("-");
        //fileName.AppendLine(type);
        //fileName.Append(ConstantManager.XmlExtention);

        //if (!Directory.Exists(folderPath.ToString()))
        //{
        //    Directory.CreateDirectory(folderPath.ToString());
        //}

        //StringBuilder allText = new StringBuilder();
        //allText.Append(folderPath);
        //allText.Append(fileName);

        //StringBuilder contents = new StringBuilder();
        //contents.Append(message);
        //contents.Append(Environment.NewLine);

        //File.AppendAllText(allText.ToString(), contents.ToString());
    }
}
