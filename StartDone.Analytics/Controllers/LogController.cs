using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;
using StartDone.Analytics.Models.Plugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StartDone.Analytics.Controllers
{
    public class LogController : Controller
    {
        private StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();
        // GET: Vistor
        public ActionResult Index()
        {

            List<Model_LogList> _log = new List<Model_LogList>();

            foreach (var item in db.Tbl_Log.OrderBy(a => a.Log_ID).Take(100).ToList())
            {
                _log.Add(new Model_LogList()
                {
                    ID = item.Log_ID,
                    DateTime = item.Log_DateTime.ToPeString("yyyy/MM/dd HH:MM")
                });
            }

            return View(_log);
        }


        [HttpPost]
        public ActionResult GetLog()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            List<Model_LogList> _log = new List<Model_LogList>();

            foreach (var item in db.Tbl_Log.OrderBy(a => a.Log_ID).Take(100).ToList())
            {
                _log.Add(new Model_LogList() {
                    ID = item.Log_ID ,
                    DateTime = item.Log_DateTime.ToPeString("yyyy/MM/dd HH:MM") });

            }

            int totalRows = _log.Count;

            if (!string.IsNullOrEmpty(searchValue))
            {
                _log = _log.Where(x => x.ID.ToString().ToLower().Contains(searchValue.ToLower()) ||
                                               x.ID.ToString().ToLower().Contains(searchValue.ToLower()) ||
                                               x.DateTime.ToLower().Contains(searchValue.ToLower())).ToList();
            }

            int totalRowsAfterFiltering = _log.Count;

            _log = _log.OrderBy(sortColumnName + " " + sortDirection).ToList();

            _log = _log.Skip(start).Take(length).ToList();

            return Json(new { data = _log, draw = Request["draw"], recordsTotal = totalRows, recordsFiltered = totalRowsAfterFiltering }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LogShow(int ID)
        {
            var q = db.Tbl_Log.Where(a => a.Log_ID == ID).Take(100).SingleOrDefault().Log_Raw;

            Model_LogShow logShow = new Model_LogShow();

            logShow.Raw = q;

            return PartialView(logShow);
        }
    }
}