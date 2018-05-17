using Common.Logging;
using Common.Service.Wcf.Extensions.Attributes;
using Sample.Service.Wcf.DataModels;
using Sample.Service.Wcf.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Sample.Service.Wcf
{
    [ActivityIdServiceBehavior]
    public class Service : IEmployeeService
    {
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(Service));

        public IEnumerable<Employee> GetEmployees()
        {
            using (LoggingBlock lg = _logger.GetLoggingBlock())
            {
                var employee = new Employee { FirstName = "Joe", LastName = "Smith" };
                return new Employee[] { employee };
            }
        }
    }
}
