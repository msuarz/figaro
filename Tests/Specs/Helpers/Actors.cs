using Figaro;

namespace Specs.Helpers {

    public class Actors {

        public static HttpFixture HttpFixture { get { return new HttpFixture {
            Host = "host",
            Uri = "uri"
        };}}
    }
}