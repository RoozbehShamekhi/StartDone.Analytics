using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StartDone.Analytics.Controllers
{
    public class ApiLogController : ApiController
    {
        private readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        [HttpPost]
        public void Post([FromBody] object analiseData)
        {
            //Tbl_Log _Log = new Tbl_Log
            //{
            //    Log_Raw = analiseData
            //};

            //db.Tbl_Log.Add(_Log);

            //db.SaveChanges();
        }
    }
}
