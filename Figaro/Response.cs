using System.Net;

namespace Figaro {

    public interface Response {

        WebHeaderCollection Headers { get; }
        string ContentType { get; }
        string Content { get; }
    }
}