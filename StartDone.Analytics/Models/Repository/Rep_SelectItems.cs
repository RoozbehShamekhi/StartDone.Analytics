using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;

namespace Wtiau.Health.Web.Models.Repository
{
    public class Rep_SelectItems
    {
        private static readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        //public IEnumerable<SelectListItem> Get_AllUnivercity()
        //{
        //    List<SelectListItem> list = new List<SelectListItem>();


        //    foreach (var item in db.Tbl_University)
        //    {
        //        list.Add(new SelectListItem() { Value = item.University_ID.ToString(), Text = item.University_Display });
        //    }

        //    return list.AsEnumerable();
        //}


    }
}