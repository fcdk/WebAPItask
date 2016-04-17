using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SDSK.API.Handlers
{
    public class MethodOverrideHandler : DelegatingHandler
    {
        private const string Method = "POST";
        private const string Header = "NewMethod";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Check for HTTP PUT with the NewMethod header.
            if (request.Method == HttpMethod.Put && request.Headers.Contains(Header))
            {
                // Check if the header value is in our methods list.
                var method = request.Headers.GetValues(Header).FirstOrDefault();
                if (String.Equals(Method, method, StringComparison.InvariantCultureIgnoreCase))
                {
                    // Change the request method.
                    request.Method = new HttpMethod(method);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
