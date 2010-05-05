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
            ClearFieldsAndSetMethodAndUri("GET", URI);
        }

        public void Head(string URI) {
            ClearFieldsAndSetMethodAndUri("HEAD",URI);
        }

        private void ClearFieldsAndSetMethodAndUri(string method, string URI) {
            ClearFields();
            this.Method = method;
            this.URI = URI;
        }

        void ClearFields() {
            Method = Host = Authorization = UserName = Password = null;
        }

        string URI { get; set; }
        string Method { get; set; }

        WebRequest Request { get; set; }
        WebResponse Response { get; set; }


        public string Host { get; set; }
        public string Authorization { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Send() {
            Request = WebRequest.Create(RequestUriString);
            AddAuthorization();
            Request.Method = Method;
            Response = Request.GetResponse();
        }

        void AddAuthorization() { 
            if (string.IsNullOrEmpty(Authorization)) return;

            var Token = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(UserName + ":" + Password));
            
            Request.Headers.Add("Authorization", Authorization + " " + Token);
        }

        public Fixture ResponseHeader { get { return new 
            HeaderFixture(Response.Headers)
        ;}}

        public Fixture ResponseBody { get { return new 
            ResponseBodyFixture(ResponseContent)
        ;}}

        string ResponseContent { get {
            using(var Reader = new StreamReader(Response.GetResponseStream()))
                return Reader.ReadToEnd()
        ;}}
    }
}