using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartDone.Analytics.Models.ViewModels
{
    public class Model_IPAddressList
    {
        [Display(Name = "ردیف")]
        public int ID { get; set; }
        [Display(Name = "IPAddress")]
        public string  IP { get; set; }
        [Display(Name = "کشور")]
        public string country { get; set; }
        [Display(Name = "شهر")]
        public string City { get; set; }
        [Display(Name = "ISP")]
        public string ISP { get; set; }

    }
}