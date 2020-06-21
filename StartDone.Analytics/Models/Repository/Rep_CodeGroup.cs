using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StartDone.Analytics.Models.Domian;

namespace StartDone.Analytics.Models.Repository
{
    public static class Rep_CodeGroup
    {
        private static readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        public static IEnumerable<SelectListItem> Get_AllCodesWithGroupID(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            var q = db.Tbl_CodeGroup.Where(x => x.CG_ID.Equals(id)).SingleOrDefault().Tbl_Code.ToList();

            foreach (var item in q)
            {
                list.Add(new SelectListItem() { Value = item.Code_ID.ToString(), Text = item.Code_Display });
            }

            return list.AsEnumerable();
        }

        public static string Get_CodeDisplayWithID(int id)
        {
            return db.Tbl_Code.Where(x => x.Code_ID == id).SingleOrDefault().Code_Display;
        }

        public static int Get_CodeIDWithName(string name)
        {
            return db.Tbl_Code.Where(x => x.Code_Name.Equals(name)).SingleOrDefault().Code_ID;
        }
    }
}
