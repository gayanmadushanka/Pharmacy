using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Ccom.Common.Utils
{
    public class FileOperation
    {
        public static void CreateDirectory(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///<summary>
        /// Encrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        public static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123"; // Your Key Here
                UnicodeEncoding ue = new UnicodeEncoding();
                byte[] key = ue.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged rmCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, rmCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);

                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }
        ///<summary>
        /// Steve Lydford - 12/05/2008.
        ///
        /// Decrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        private static void DecryptFile(string inputFile, string outputFile)
        {
            string password = @"myKey123"; // Your Key Here

            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] key = ue.GetBytes(password);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

            RijndaelManaged rmCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt, rmCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
        }
    }
}
