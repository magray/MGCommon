using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MGCommon
{
    public class Serializer
    {
        public static T DeserializeFile<T>(string fileName)
        {
            using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return Deserialize<T>(stream);
            }
        }

        public static T DeserializeString<T>(string xmlString)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlString);
            return DeserializeXmlNode<T>(xdoc);
        }

        public static T Deserialize<T>(Stream stream)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(stream);
        }

        public static T DeserializeXmlNode<T>(XmlNode xmlnode)
        {
            using (XmlNodeReader nodereader = new XmlNodeReader(xmlnode))
            {
                return Deserialize<T>(nodereader);
            }
        }

        public static T Deserialize<T>(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(reader);
        }

        public static bool Serialize<T>(T value, string filename)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                using (var writer = new System.IO.StreamWriter(filename))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, value);
                    writer.Flush();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static string SerializeToString<T>(T value)
        {
            return SerializeToString(value, false);
        }

        public static string SerializeToString<T>(T value, bool omitXmlDeclaration)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                var settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = omitXmlDeclaration;
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                using (StringWriter stream = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    ser.Serialize(writer, value, ns);
                    return stream.ToString();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
