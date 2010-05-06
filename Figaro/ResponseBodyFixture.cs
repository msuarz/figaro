using fit;
using System;

namespace Figaro {

    public class ResponseBodyFixture : ColumnFixture {

        Body body;
        public virtual Body Body { get { return body ?? InitBody; } }
        Body InitBody { get {

            if (string.IsNullOrEmpty(XPath)) 
                body = new JsonBody(Content);
            else body = new XmlBody(Content);

            return body;
        }}

        public string Content { get; set; }

        public string XPath { get; set; }

        public string JsonProperty { get; set; }

        public string Value { get {
            
            if (string.IsNullOrEmpty(XPath) && string.IsNullOrEmpty(JsonProperty)) 
                throw new Exception("Please set XPath or JSONProperty.");
            
            return Body.ValueOf(Part);
        }}

        string Part { get { return 
            string.IsNullOrEmpty(XPath) ? 
                JsonProperty : XPath
        ;}}

        public bool IsEmpty { get { return String.IsNullOrEmpty(Content); } }
    }
}