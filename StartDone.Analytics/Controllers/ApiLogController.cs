using StartDone.Analytics.Models.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StartDone.Analytics.Controllers
{
    [Route("api/[controller]")]
    public class ApiLogController : ApiController
    {
        private StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        [HttpPost]
        public void Post([FromBody] string analiseData) 
        {
            Tbl_Log _Log = new Tbl_Log();

            _Log.Log_Raw = analiseData;

            db.Tbl_Log.Add(_Log);

            db.SaveChanges();
          
        }

    }
}
