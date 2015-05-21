using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ccom.Common.Utils
{
    public class XmlSerializerUtil
    {
        public static string Serialize<T>(T item)
        {
            try
            {
                var memStream = new MemoryStream();
                using (var textWriter = new XmlTextWriter(memStream, Encoding.Unicode))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(textWriter, item);

                    memStream = textWriter.BaseStream as MemoryStream;
                }
                return memStream != null ? Encoding.Unicode.GetString(memStream.ToArray()) : null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static void SerializeObjectToXML<T>(T obj, string path)
        //{
        //    try
        //    {
        //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        //        TextWriter textWriter = new StreamWriter(path);
        //        xmlSerializer.Serialize(textWriter, obj);
        //        textWriter.Close();
        //        textWriter.Dispose();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public static T DeSerializeXmlToObject<T>(string path)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                TextReader textReader = new StreamReader(path);
                T deserialize = (T)xmlSerializer.Deserialize(textReader);
                textReader.Close();
                textReader.Dispose();
                return deserialize;
            }
            catch
            {
                throw;
            }
        }

        public static T DeSerializeXmlToObject<T>(string path,string nameSpace,XmlRootAttribute xmlRootAttribute)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T), null, Type.EmptyTypes,xmlRootAttribute,nameSpace);

                TextReader textReader = new StreamReader(path);
                T deserialize = (T)xmlSerializer.Deserialize(textReader);
                textReader.Close();
                textReader.Dispose();
                return deserialize;
            }
            catch
            {
                throw;
            }
        }
    }
}
