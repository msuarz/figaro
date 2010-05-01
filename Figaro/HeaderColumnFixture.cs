using System.Net;
using fit;

namespace Figaro {

    class HeaderColumnFixture : ColumnFixture {

        public WebHeaderCollection Headers { get; set; }

        public HeaderColumnFixture(WebHeaderCollection Headers) {
            this.Headers = Headers;
        }

        public string Name { get; set; }

        public string Value { get { return Headers[Name]; } }
    }
}
