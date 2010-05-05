using System.Xml.Linq;
using System.Xml.XPath;

namespace Figaro
{
    class XMLResult
    {

        public static XMLResult GetValueFor(string xPath)
        {
            return new XMLResult(xPath);
        }

        string XPath { get; set; }

        private XMLResult(string xPath)
        {
            XPath = xPath;
        }

        public string ContainedIn(string rawXml)
        {
            return XDocument.Parse(rawXml).XPathSelectElement(XPath).Value;
        }

    }
}
