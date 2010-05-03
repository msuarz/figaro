using System;
using System.IO;
using System.Net;
using fit;

namespace Figaro {
    
    public class Figaro {

        string RequestUriString { get { return 
            string.IsNullOrEmpty(Host) ? URI : "http://" + Host + "/" + URI; 
        }}

        public void Get(string URI) {
            ClearFields();
            this.URI = URI;
        }

        void ClearFields() {
            Host = Authorization = UserName = Password = null;
        }

        string URI { get; set; }

        WebRequest Request { get; set; }
        WebResponse Response { get; set; }

        public string Host { get; set; }
        public string Authorization { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Send() {
            Request = WebRequest.Create(RequestUriString);
            AddAuthorization(); 
            Response = Request.GetResponse();
        }

        void AddAuthorization() { 
            if (string.IsNullOrEmpty(Authorization)) return;

            var Token = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(UserName + ":" + Password));
            
            Request.Headers.Add("Authorization", Authorization + " " + Token);
        }

        public Fixture ResponseHeader {
            get { return new HeaderColumnFixture(Response.Headers); }
        }

        public Fixture ResponseBody { get {
            var Fixture = new ColumnFixture();

            using( var Reader = new StreamReader(Response.GetResponseStream()))
                Fixture.SetSystemUnderTest(new { Content = Reader.ReadToEnd() });

            return Fixture;
        }}
    }
}