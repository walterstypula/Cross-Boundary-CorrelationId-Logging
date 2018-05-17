using Common.Logging;
using Common.Proxy.Wcf;
using Sample.Service.Proxy.Wcf.Client;
using Sample.Service.Wcf.DataModels;
using Sample.Service.Wcf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Console
{
    class Program
    {
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {

            var client = new EmployeeServiceProxy();

            var employees = client.Execute(p => p.GetEmployees());
  

            _logger.Debug("Yellow");
        }
    }
}
