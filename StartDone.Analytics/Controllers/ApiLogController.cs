using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using Hangfire;

namespace StartDone.Analytics.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ApiLogController : ApiController
    {
        private readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        [HttpPost]
        public void Post([FromBody] object analiseData)
        {
            if (analiseData != null)
            {
                Tbl_Log _Log = new Tbl_Log();

                _Log.Log_Raw = analiseData.ToString();
                _Log.Log_DateTime = DateTime.Now;

                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                {
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                _Log.Log_IP = ip;


                db.Tbl_Log.Add(_Log);

                db.SaveChanges();

                BackgroundJob.Enqueue(() => test());

            }
 
        }

        public string test()
        {
            return "joon from api";
        }
    }
}
