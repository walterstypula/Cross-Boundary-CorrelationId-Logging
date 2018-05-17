using Common.Client.Wcf.Extensions.Inspectors;
using System.ServiceModel.Description;

namespace Common.Client.Wcf.Extensions.Behaviors
{
    public class ActivityIdEndpointBehavior : IEndpointBehavior

    {
        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            var inspector = new ActivityIdMessageInspector();
            clientRuntime.MessageInspectors.Add(inspector);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)

        {
        }

        #endregion IEndpointBehavior Members
    }
}