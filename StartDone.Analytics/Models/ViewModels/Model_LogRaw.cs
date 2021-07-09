using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartDone.Analytics.Models.ViewModels
{
    public class Model_LogRaw
    {
        public string Code { get; set; }
        public string ratio { get; set; }
        public string BrowserCodeName { get; set; }
        public string browserName { get; set; }
        public string browserVersion { get; set; }
        public string backLink { get; set; }
        public string url { get; set; }
        public string platform { get; set; }
        public string userAgent { get; set; }
    }
}