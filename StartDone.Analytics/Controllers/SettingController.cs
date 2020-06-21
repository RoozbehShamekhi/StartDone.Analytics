using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;

namespace StartDone.Analytics.Controllers
{
    public class SettingController : Controller
    {
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}