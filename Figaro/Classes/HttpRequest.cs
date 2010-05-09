using System.Net;

namespace Figaro.Classes {

    public class HttpRequest : Request, Wrap<WebRequest> {
        
        public WebRequest Core { get; set; }

        public Response Response { get { return 
            new HttpResponse { Core = Core.GetResponse() }
        ;}}
    }
}