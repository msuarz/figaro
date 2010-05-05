using System.Xml.Linq;
using System.Xml.XPath;

namespace Figaro
{
    class XMLResult
    {

        static XMLResult Instance { get; set; }

        public static XMLResult ContainedIn(string content)
        {
            if (Instance == null) Instance = new XMLResult(content);
            return Instance;
        }

        XDocument Document { get; set; }

        private XMLResult(string content)
        {
            Document = XDocument.Parse(content);
        }

        public string GetValueFor(string XPath)
        {
            return Document.XPathSelectElement(XPath).Value;
        }

    }
}
