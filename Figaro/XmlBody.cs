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
            if (!Part.StartsWith("/")) Part = "/" + Part.Replace(".", "/");
             return Document.XPathSelectElement(Part).Value;
        }

    }
}
