using System.Xml;
using fit;

namespace Figaro {

    public class ResponseBodyFixture : ColumnFixture {

        public ResponseBodyFixture(string Content) {
            this.Content = Content;
        }

        XmlDocument xml;
        XmlDocument Xml { get { return xml ?? LoadXml; } }
        XmlDocument LoadXml { get {
            xml = new XmlDocument();
            xml.LoadXml(Content);
            return xml;
        }}

        public string Content { get; set; }

        public string XPath { get; set; }

        public string Value { get { return
            Xml.SelectSingleNode(XPath).FirstChild.Value
        ;}}
    }
}