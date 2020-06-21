using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartDone.Analytics.Models.Domian;

namespace StartDone.Analytics.Models.Repository
{
    public static class Rep_UserRole
    {
        private static readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();
        public static string Get_RoleNameWithID(int id)
        {
            return db.Tbl_Role.Where(a => a.Role_ID == id).SingleOrDefault().Role_Name;
        }
    }
}
