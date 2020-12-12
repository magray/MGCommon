using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml;

namespace MGCommon
{
    public static class XmlExtensions
    {
        public static string GetAttributeText(this XmlElement element, string attribute)
        {
            string value = element.GetAttribute(attribute);
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return value;
        }

        public static string GetNodeAttributeText(this XmlElement element, string xpath, string attribute)
        {
            XmlElement xmlElement = (XmlElement)element.SelectSingleNode(xpath);
            if (xmlElement == null)
            {
                return null;
            }
            return xmlElement.GetAttributeText(attribute);
        }

        public static string GetNodeText(this XmlElement element, string xpath)
        {
            XmlNode node = element.SelectSingleNode(xpath);
            if (node == null)
            {
                return null;
            }
            string innerText = node.InnerText;
            return innerText;
        }

        public static XmlElement SelectSingleElement(this XmlNode node, string xpath)
        {
            XmlElement element;
            try
            {
                element = node.SelectSingleNode(xpath) as XmlElement;
            }
            catch
            {
                element = null;
            }
            return element;
            
        }
    }
}
