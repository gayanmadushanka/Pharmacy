using System;
using System.IO;
using System.Text;
using Ccom.ExceptionHandling.ExceptionHandlers;
using iTextSharp.text.pdf;

namespace Ccom.Common.Utils
{
    public static class PdfHelper
    {
        public static void EncryptPdfFile(string inputFile, string outputFile, string publicKey, string privateKey)
        {
            try
            {
                using (Stream input = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (Stream output = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        PdfReader reader = new PdfReader(input);
                        PdfEncryptor.Encrypt(reader, output, true, publicKey, privateKey, PdfWriter.ALLOW_SCREENREADERS);
                    }
                }
            }
            catch (Exception ex)
            {
                if (CommonExceptionHandler.HandleException(ref ex)) throw ex;
            }
        }

        public static void DecryptPdfFile(string inputFile, string outputFile, string privateKey)
        {
            try
            {
                PdfReader reader = new PdfReader(inputFile, new ASCIIEncoding().GetBytes(privateKey));

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfStamper stamper = new PdfStamper(reader, memoryStream);
                    stamper.Close();
                    reader.Close();
                    File.WriteAllBytes(outputFile, memoryStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                if (CommonExceptionHandler.HandleException(ref ex)) throw ex;
            }
        }
    }
}
