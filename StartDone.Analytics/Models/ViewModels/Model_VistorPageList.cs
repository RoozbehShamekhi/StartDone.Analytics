using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartDone.Analytics.Models.ViewModels
{
    public class Model_VistorPageList
    {
        public int PV_ID { get; set; }
        public string IP { get; set; }
        public string PageUrl { get; set; }
        public string Referrer { get; set; }
        public string WindowSize { get; set; }
        public string Brower { get; set; }
        public string BrowerInfo { get; set; }
        public string Platform { get; set; }
        public string UserAgent { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}