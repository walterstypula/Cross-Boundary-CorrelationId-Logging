using Common.Client.Wcf.Extensions.Behaviors;
using Common.Proxy.Wcf;
using Sample.Service.Wcf.Interfaces;

namespace Sample.Service.Proxy.Wcf.Client
{
    public class EmployeeServiceProxy : Proxy<IEmployeeService>
    {
        public EmployeeServiceProxy() : base()
        {
            Channel.Endpoint.EndpointBehaviors.Add(new ActivityIdEndpointBehavior());
        }
    }
}