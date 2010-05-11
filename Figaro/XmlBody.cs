using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Figaro {

    public class XmlBody : Body {

        XDocument document;
        XDocument Document { get { return document ?? LoadDocument; } }
        XDocument LoadDocument { get { return document = XDocument.Parse(Content); } }

        public string Content { get; set; }

        public string ValueOf(string Part) {
            return Part.StartsWith("/") ?
                Document.XPathSelectElement(Part).Value :
                ValueOfObject(Part);
        }

        public virtual string ValueOfObject(string part)
        {
            return null;
        }
    }
}
