using System.Xml.Linq;
using System.Xml.XPath;

namespace Figaro {

    public class XmlBody : Body {

        XDocument document;
        XDocument Document { get { return document ?? LoadDocument; } }
        XDocument LoadDocument { get { return document = XDocument.Parse(Content); } }

        public string Content { get; set; }

        public string ValueOf(string Part, string PartPrefix = ""){
            
            if (!string.IsNullOrEmpty(PartPrefix)) 
                PartPrefix = "/" + PartPrefix.Replace(".","/");

            if (!Part.StartsWith("/")) Part = "/" 
                + Part.Replace(".", "/");

            Part = PartPrefix + Part;

            return Document.XPathSelectElement(Part).Value;
        }

    }
}
