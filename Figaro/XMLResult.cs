using System.Xml.Linq;
using System.Xml.XPath;

namespace Figaro
{
    class XMLResult
    {

        static XMLResult Instance { get; set; }

        public static XMLResult ContainedIn(string rawXml)
        {
            if (Instance == null) Instance = new XMLResult(rawXml);
            return Instance;
        }

        XDocument Document { get; set; }

        private XMLResult(string rawXml)
        {
            Document = XDocument.Parse(rawXml);
        }

        public string GetValueFor(string xPath)
        {
            return Document.XPathSelectElement(xPath).Value;
        }

    }
}
