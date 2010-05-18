using System.Net;
using fit;

namespace Figaro {

    class HeaderFixture : ColumnFixture {

        public WebHeaderCollection Headers { get; set; }

        public string Name { get; set; }

        public string Value {
            get { return Headers[Name]; }
            set { Headers[Name] = value; }
        }
    }
}
