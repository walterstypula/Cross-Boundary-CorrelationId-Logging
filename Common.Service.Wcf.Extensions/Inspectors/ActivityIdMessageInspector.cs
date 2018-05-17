using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Wcf.Extensions.Inspectors
{
    public class ActivityIdMessageInspector : IDispatchMessageInspector
    {
        private const string X_ACTIVITY_ID_HTTP_HEADER = "x-activity-id";

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            object prop;
            string myHeader;

            if (!OperationContext.Current.IncomingMessageProperties.TryGetValue(HttpRequestMessageProperty.Name, out prop))
            {
                myHeader = Guid.NewGuid().ToString();
            }
            else
            {
                HttpRequestMessageProperty reqProp = (HttpRequestMessageProperty)prop;
                myHeader = reqProp.Headers[X_ACTIVITY_ID_HTTP_HEADER];
            }

            Trace.CorrelationManager.ActivityId = Guid.Parse(myHeader);

            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {

        }
    }
}
