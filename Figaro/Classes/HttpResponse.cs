using System.IO;
using System.Net;

namespace Figaro.Classes {

    public class HttpResponse : Response, Wrap<WebResponse> {

        public WebResponse Core { get; set; }

        public WebHeaderCollection Headers { get { return Core.Headers; }}

        public string ContentType { get { return
            Core.Headers["Content-Type"]
        ;}}

        public string Content { get {
            using (var Reader = new StreamReader(Core.GetResponseStream()))
                return Reader.ReadToEnd()
        ;}}
    }
}