using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace MGCommon
{
    public abstract class XmlFile
    {
        private XmlDocument xml_doc;

        protected IXPathNavigable Doc
        {
            get
            {
                return xml_doc;
            }
        }

        public string FilePath { get; }

        protected XmlFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("filePath");
            }
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }
            FilePath = filePath;
            xml_doc = new XmlDocument();
            xml_doc.Load(FilePath);
        }
    }
}
