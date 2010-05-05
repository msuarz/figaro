using System.Xml.Linq;
using System.Xml.XPath;
using fit;

namespace Figaro {

    public class ResponseBodyFixture : ColumnFixture {

        public ResponseBodyFixture(string Content) {
            this.Content = Content;
        }

        XDocument body;
        XDocument Body { get { return body ?? LoadBody; } }
        XDocument LoadBody { get { return body = XDocument.Parse(Content); }}

        public string Content { get; private set; }

        public string XPath { private get; set; }

        public string Value { get { return
            Body.XPathSelectElement(XPath).Value
        ;}}
    }
}