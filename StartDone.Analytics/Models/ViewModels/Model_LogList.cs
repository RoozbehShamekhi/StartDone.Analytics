using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartDone.Analytics.Models.ViewModels
{
    public class Model_LogList
    {
        [Display(Name = "ردیف")]
        public int ID { get; set; }
        [Display(Name = "IP")]
        public string IP { get; set; }
        [Display(Name = "تاریخ")]
        public string DateTime { get; set; }
    }
}