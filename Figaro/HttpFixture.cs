using Figaro.Classes;
using fit;

namespace Figaro {
    
    public class HttpFixture {

        public HttpFixture() {
            RequestFactory = new RequestFactoryClass();
        }

        public string Method { get; set; }
        public string Uri { get; set; }
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

        public RequestFactory RequestFactory { get; set; }

        public Response Response { get; private set; }

        public void Send() {
            Response = RequestFactory.NewRequest(this).Response;
        }

        public Fixture ResponseHeader { get { return new 
            HeaderFixture(Response.Headers)
        ;}}

        public Fixture ResponseBody { get { return 
            BodyFactory.NewResponseBodyFixture(
                Response.ContentType, Response.Content)
        ;}}
    }
}