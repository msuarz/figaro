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
            if (!String.IsNullOrEmpty(XPath)) value = XMLResult.ContainedIn(Content).GetValueFor(XPath);
            else if (!String.IsNullOrEmpty(JSONProperty)) value = JSONResult.ContainedIn(Content).GetValueFor(JSONProperty);
            return value;
        }
    }
}