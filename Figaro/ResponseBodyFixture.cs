using System.Xml;
using fit;

namespace Figaro {

    public class ResponseBodyFixture : ColumnFixture {

        public ResponseBodyFixture(string Content) {
            this.Content = Content;
        }

        XmlDocument body;
        XmlDocument Body { get { return body ?? LoadBody; } }
        XmlDocument LoadBody { get {
            body = new XmlDocument();
            body.LoadXml(Content);
            return body;
        }}

        public string Content { get; private set; }

        public string XPath { private get; set; }

        public string Value { get { return
            Body.SelectSingleNode(XPath).FirstChild.Value
        ;}}
    }
}