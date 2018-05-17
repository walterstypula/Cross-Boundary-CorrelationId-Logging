using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Common.Client.Wcf.Extensions.Inspectors
{
    public class ActivityIdMessageInspector : IClientMessageInspector
    {
        private const string X_ACTIVITY_ID_HTTP_HEADER = "x-activity-id";

        private string ActivityId
        {
            get
            {
                var guid = Trace.CorrelationManager.ActivityId;
                if (guid == Guid.Empty)
                {
                    guid = Guid.NewGuid();
                }

                return guid.ToString();
            }
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            HttpRequestMessageProperty httpRequestMessage;

            object httpRequestMessageObject;

            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;

                if (string.IsNullOrEmpty(httpRequestMessage.Headers[X_ACTIVITY_ID_HTTP_HEADER]))
                {
                    httpRequestMessage.Headers[X_ACTIVITY_ID_HTTP_HEADER] = ActivityId;
                }
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();

                httpRequestMessage.Headers.Add(X_ACTIVITY_ID_HTTP_HEADER, ActivityId);

                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }

            return null;
        }
    }
}