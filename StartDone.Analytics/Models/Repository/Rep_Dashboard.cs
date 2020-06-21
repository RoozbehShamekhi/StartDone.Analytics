using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;

namespace StartDone.Analytics.Models.Repository
{
    public class Rep_Dashboard
    {
        private static readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        public Rep_Dashboard()
        {

        }

        public Model_DashBoardInfo info()
        {
            Model_DashBoardInfo model = new Model_DashBoardInfo();
            //model.StudentInSystemCount = db.Tbl_Student.Count();
            //model.StudentInfoCount = db.Tbl_StudentInfo.Count();
            //model.TakeTimeCount = db.Tbl_TakeTurn.Count();

            return model;

        }

    }
}