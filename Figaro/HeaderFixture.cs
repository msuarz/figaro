using System.Net;
using fit;

namespace Figaro {

    class HeaderFixture : ColumnFixture {

        public HeaderFixture(WebHeaderCollection Headers) {
            this.Headers = Headers;
        }

        public WebHeaderCollection Headers { get; set; }

        public string Name { get; set; }

        public string Value {
            get { return Headers[Name]; }
            set { Headers[Name] = value; }
        }
    }
}
