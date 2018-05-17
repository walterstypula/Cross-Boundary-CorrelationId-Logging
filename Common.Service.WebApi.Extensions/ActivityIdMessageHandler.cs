using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Service.WebApi.Extensions
{
    public class ActivityIdMessageHandler : DelegatingHandler
    {
        private const string X_ACTIVITY_ID_HTTP_HEADER = "x-activity-id";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string myHeader;

            if (!request.Headers.Contains(X_ACTIVITY_ID_HTTP_HEADER))
            {
                myHeader = Guid.NewGuid().ToString();
            }
            else
            {
                myHeader = request.Headers.GetValues(X_ACTIVITY_ID_HTTP_HEADER).FirstOrDefault();
            }

            Trace.CorrelationManager.ActivityId = Guid.Parse(myHeader);

            return base.SendAsync(request, cancellationToken);
        }
    }
}