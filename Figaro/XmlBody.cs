using System.Xml.Linq;
using System.Xml.XPath;

namespace Figaro {

    public class XmlBody : Body {

        XDocument Document { get; set; }

        public XmlBody(string Content) {
            Document = XDocument.Parse(Content);
        }

        public string ValueOf(string Part) { return 
            Document.XPathSelectElement(Part).Value
        ;}
    }
}
