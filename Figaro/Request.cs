using System.Collections.Specialized;

namespace Figaro {

    public interface Request {

        string Method { get; set; }

        Response Response { get; }
        NameValueCollection Headers { get; }
    }
}