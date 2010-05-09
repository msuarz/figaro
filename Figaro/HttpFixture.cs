using System;
using System.IO;
using System.Net;
using System.Threading;
using fit;

namespace Figaro {
    
    public class HttpFixture {

        public void Sleep(int Sec) { Thread.Sleep(Sec * 1000); }

        public string Host { get; set; }
        public string Authorization { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Get(string Uri) { SetUpNewRequest("GET", Uri); }
        public void Head(string Uri) { SetUpNewRequest("HEAD", Uri); }
        
        void SetUpNewRequest(string Method, string Uri) {
            this.Method = Method;
            this.Uri = Uri;
            Host = Authorization = UserName = Password = null;
        }

        public string Method { get; set; }
        public string Uri { get; private set; }

        public virtual string RequestUriString { get { return 
            string.IsNullOrEmpty(Host) ? Uri : "http://" + Host + "/" + Uri; 
        }}
        void AddAuthorization() { 
            if (string.IsNullOrEmpty(Authorization)) return;

            var Token = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(UserName + ":" + Password));
            
            Request.Headers.Add("Authorization", Authorization + " " + Token);
        }

        public WebRequest Request { get; set; }
        public WebResponse Response { get; set; }

        public void Send() {
            PrepareRequest();
            GetResponse();
        }

        public virtual void PrepareRequest() {
            Request = WebRequest.Create(RequestUriString);
            AddAuthorization();
            Request.Method = Method;
        }

        public virtual void GetResponse() {
            Response = Request.GetResponse();
        }

        public Fixture ResponseHeader { get { return new 
            HeaderFixture(Response.Headers)
        ;}}
        public Fixture ResponseBody { get { return 
            BodyFactory.NewResponseBodyFixture(ContentType, ResponseContent)
        ;}}

        string ContentType { get { return Response.Headers["Content-Type"]; }}
        string ResponseContent { get {
            using (var Reader = new StreamReader(Response.GetResponseStream()))
                return Reader.ReadToEnd()
        ;}}
    }
}