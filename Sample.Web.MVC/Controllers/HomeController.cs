using Common.Logging;
using Sample.Service.Wcf.DataModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;

namespace Sample.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private const string X_ACTIVITY_ID_HTTP_HEADER = "x-activity-id";
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            using (var lg = _logger.GetLoggingBlock())
            {
                string apiUrl = "http://localhost:51033/api/employees";
                IEnumerable<Employee> employees = null;

                using (WebClient client = new WebClient())
                {
                    client.Headers.Clear();
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    client.Headers.Add(X_ACTIVITY_ID_HTTP_HEADER, Trace.CorrelationManager.ActivityId.ToString());
                    var data = client.DownloadString(apiUrl);

                    employees = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Employee>>(data);
                }

                return View(employees);
            }
        }
    }
}