using Common.Logging;
using Sample.Service.Proxy.Wcf.Client;
using Sample.Service.Wcf.DataModels;
using System.Collections.Generic;
using System.Web.Http;

namespace Sample.Service.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(EmployeesController));

        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            using (var lg = _logger.GetLoggingBlock())
            {
                var client = new EmployeeServiceProxy();
                return client.Execute(c => c.GetEmployees());
            }
        }
    }
}