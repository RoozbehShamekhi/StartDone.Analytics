using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;

namespace StartDone.Analytics.Models.Repository
{
    public class Rep_User
    {
        private static readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();


        public Rep_User()
        {

        }

        public Model_AccountInfo GetInfoForNavbar(string Username)
        {
            var q = db.Tbl_User.Where(a => a.User_Mobile == Username).SingleOrDefault();

            if (q != null)
            {
                Model_AccountInfo infoModel = new Model_AccountInfo();
                infoModel.Name = q.User_Name + " " + q.User_Family;
                infoModel.Role = q.Tbl_Role.Role_Display;
                return infoModel;
            }
            else
            {
                return null;
            }
        }

        public int Get_IDByUserName(string Username)
        {
            var id = db.Tbl_User.Where(a => a.User_Mobile == Username).SingleOrDefault().User_ID;

            return (int)id;
        }
    }
}
