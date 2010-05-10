using Figaro;

namespace Specs.Helpers {

    public class Actors {

        public static HttpFixture HttpFixture { get { return new HttpFixture {
            Method = "GET",
            Host = "host",
            Uri = "uri",
        };}}
    }
}