using fit;
using System;

namespace Figaro {

    public class ResponseBodyFixture : ColumnFixture {

        public ResponseBodyFixture(string Content) {
            this.Content = Content;
        }

        public string Content { get; private set; }

        public string XPath { private get; set; }

        public string JSONProperty { private get; set; }

        public string Value { get { return GetValue(); } }

        private string GetValue()
        {
            var value = string.Empty;
            if (!String.IsNullOrEmpty(XPath)) value = XMLResult.GetValueFor(XPath).ContainedIn(Content);
            else if (!String.IsNullOrEmpty(JSONProperty)) value = JSONResult.GetValueFor(JSONProperty).ContainedIn(Content);
            return value;
        }
    }
}