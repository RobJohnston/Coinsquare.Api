using System.Net.Http;

namespace Coinsquare.Api
{
    /// <summary>
    /// Request context.
    /// </summary>
    internal class RequestContext
    {
        /// <summary>
        /// Gets or sets the HTTP request object.
        /// </summary>
        public HttpRequestMessage HttpRequest { get; set; }
    }

    /// <summary>
    /// Response context.
    /// </summary>
    internal class ResponseContext
    {
        /// <summary>
        /// Gets or sets the HTTP response object.
        /// </summary>
        public HttpResponseMessage HttpResponse { get; set; }
    }
}
