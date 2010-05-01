using System.IO;
using System.Net;
using fit;

namespace Figaro {
    
    public class Figaro {

        string RequestUriString { get { return "http://" + Host + "/" + Resource; } }

        public void Get(string Resource) {
            this.Resource = Resource;
        }

        string Resource { get; set; }
        public string Host { get; set; }
        WebResponse Response { get; set; }

        public void Send() {
            Response = WebRequest.Create(RequestUriString).GetResponse();
        }
        
        public Fixture ResponseHeader {
            get { return new HeaderColumnFixture(Response.Headers); }
        }

        public Fixture ResponseBody { get {
            var Fixtureixture = new ColumnFixture();

            using( var Reader = new StreamReader(Response.GetResponseStream()))
                Fixtureixture.SetSystemUnderTest(new { Content = Reader.ReadToEnd() });

            return Fixtureixture;
        }}
    }
}