using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using fit;

namespace Figaro {
    
    public class Figaro {
        
        public void Debug() { Debugger.Launch(); }

        string RequestUriString { get { return 
            string.IsNullOrEmpty(Host) ? Uri : "http://" + Host + "/" + Uri; 
        }}

        public void Get(string Uri) { SetUpRequest("GET", Uri); }

        public void Head(string Uri) { SetUpRequest("HEAD", Uri); }

        private void SetUpRequest(string Method, string Uri) {
            ClearFields();
            this.Method = Method;
            this.Uri = Uri;
        }

        void ClearFields() {
            Method = Host = Authorization = UserName = Password = null;
        }

        string Uri { get; set; }
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

        public Fixture ResponseBody { get { return 
            BodyFactory.NewResponseBodyFixture(ContentType, ResponseContent)
        ;}}

        string ResponseContent { get {
            using (var Reader = new StreamReader(Response.GetResponseStream()))
                return Reader.ReadToEnd()
        ;}}

        string ContentType { get { return Response.Headers["Content-Type"]; }}
    }
}