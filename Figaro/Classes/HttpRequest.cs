using System.Collections.Specialized;
using System.Net;

namespace Figaro.Classes {

    public class HttpRequest : Request, Wrap<WebRequest> {
        
        public WebRequest Core { get; set; }
        public NameValueCollection Headers { get { return Core.Headers; } }
        public string Method {
            get { return Core.Method; } 
            set { Core.Method = value; }
        }

        public Response Response { get { return 
            new HttpResponse { Core = Core.GetResponse() }
        ;}}

    }
}