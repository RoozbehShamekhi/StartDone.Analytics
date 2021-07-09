using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;
using StartDone.Analytics.Models.Repository;
using Hangfire;

namespace StartDone.Analytics.Controllers
{

    [EnableCors("*", "*", "*")]
    public class ApiLogController : ApiController
    {
        private readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        [HttpPost]
        public string Post([FromBody] object analiseData)
        {

            if (analiseData != null)
            {
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip) || ip == "unknown")
                {
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                string Session = Guid.NewGuid().ToString();
                Rep_Log log = new Rep_Log();
                var id = BackgroundJob.Enqueue(() => log.setLog(analiseData, ip, Session));


                return Session;

            }

            return null;
        }

    }
}
