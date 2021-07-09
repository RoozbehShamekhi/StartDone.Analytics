using Hangfire;
using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace StartDone.Analytics.Models.Repository
{
    public class Rep_Log
    {
        private StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        public void setLog(object raw, string ip, string Session)
        {

            Tbl_Log _Log = new Tbl_Log();

            _Log.Log_Raw = raw.ToString();
            _Log.Log_DateTime = DateTime.Now;
            _Log.Log_IP = ip;

            db.Tbl_Log.Add(_Log);


            if (Convert.ToBoolean(db.SaveChanges() > 0))
            {

                var id = BackgroundJob.Enqueue(() => setdata(_Log.Log_ID, raw, ip, Session));

            }
            else
            {
                BackgroundJob.Enqueue(() => Console.WriteLine("FAILD"));

            }
        }

        public void setdata(int id, object raw, string ip, string Session)
        {
            //Tbl_IPAddress _IP = new Tbl_IPAddress();

            //if (!db.Tbl_IPAddress.Any(a => a.IA_IP == ip))
            //{
            //    _IP.IA_IP = ip;
            //    db.Tbl_IPAddress.Add(_IP);
            //}

            Model_LogRaw logRaw = new JavaScriptSerializer().Deserialize<Model_LogRaw>(raw.ToString());

            if (string.IsNullOrWhiteSpace(logRaw.Code) && logRaw.Code != null)
            {
                if (db.Tbl_PageVisit.Any(a => a.PV_Session == logRaw.Code))
                {
                    Session = logRaw.Code;
                }
            }

            Tbl_PageVisit _PageVisit = new Tbl_PageVisit()
            {
                PV_Brower = logRaw.BrowserCodeName,
                PV_PageUrl = logRaw.url,
                PV_Referrer = logRaw.backLink,
                PV_Platform = logRaw.platform,
                PV_UserAgent = logRaw.userAgent,
                PV_WindowSize = logRaw.ratio,
                PV_BrowerInfo = logRaw.browserName,
                PV_DateTime = DateTime.Now,
                PV_LogID = id,
                PV_IPAddress = ip,
                PV_Session = Session

            };

            db.Tbl_PageVisit.Add(_PageVisit);


            if (Convert.ToBoolean(db.SaveChanges() > 0))
            {
                Console.WriteLine("Success");
                //unique_Viwe();
            }
            else
            {
                Console.WriteLine("FAILD");

            }



        }

        public void unique_Viwe()
        {
            var q = db.Tbl_PageVisit.GroupBy(a => a.PV_Session).ToList();
            var p = db.Tbl_PageVisit.GroupBy(a => a.PV_IPAddress).ToList();
        }

    }
}