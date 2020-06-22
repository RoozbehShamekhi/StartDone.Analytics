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
    public class VistorController : Controller
    {
        private StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();
        // GET: Vistor
        public ActionResult Index()
        {

            List<Model_VistorList> _Vistor = new List<Model_VistorList>();

            foreach (var item in db.Tbl_Visitor.OrderBy(a => a.Visitor_ID).Take(100))
            {
                _Vistor.Add(new Model_VistorList()
                {
                    ID = item.Visitor_ID,
                    IP = item.Tbl_IPAddress.IA_IP,
                    Type = item.Tbl_Code.Code_Display,
                    DateTime = item.Visitor_CreateDateTime.ToPeString("yyyy/MM/dd HH:MM")
                });
            }

            return View(_Vistor);
        }


        [HttpPost]
        public ActionResult GetVisitor()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            List<Model_VistorList> _Vistor = new List<Model_VistorList>();

            foreach (var item in db.Tbl_Visitor.OrderBy(a => a.Visitor_ID).Take(100))
            {
                _Vistor.Add(new Model_VistorList()
                {
                    ID = item.Visitor_ID,
                    IP = item.Tbl_IPAddress.IA_IP,
                    Type = item.Tbl_Code.Code_Display,
                    DateTime = item.Visitor_CreateDateTime.ToPeString("yyyy/MM/dd HH:MM")
                });
            }

            int totalRows = _Vistor.Count;

            if (!string.IsNullOrEmpty(searchValue))
            {
                _Vistor = _Vistor.Where(x => x.ID.ToString().ToLower().Contains(searchValue.ToLower()) ||
                                               x.ID.ToString().ToLower().Contains(searchValue.ToLower()) ||
                                               x.IP.ToLower().Contains(searchValue.ToLower()) ||
                                               x.DateTime.ToLower().Contains(searchValue.ToLower()) ||
                                               x.Type.ToLower().Contains(searchValue.ToLower())).ToList();
            }

            int totalRowsAfterFiltering = _Vistor.Count;

            _Vistor = _Vistor.OrderBy(sortColumnName + " " + sortDirection).ToList();

            _Vistor = _Vistor.Skip(start).Take(length).ToList();

            return Json(new { data = _Vistor, draw = Request["draw"], recordsTotal = totalRows, recordsFiltered = totalRowsAfterFiltering }, JsonRequestBehavior.AllowGet);
        }

    }
}