using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartDone.Analytics.Models.ViewModels
{
    public class Model_Register
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا مقدار را وارد نمایید")]
        [StringLength(100, ErrorMessage = "مقدار وارد شده بیش 100 کارکتراست")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا مقدار را وارد نمایید")]
        [StringLength(100, ErrorMessage = "مقدار وارد شده بیش 100 کارکتراست")]
        public string Family { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا مقدار را وارد نمایید")]
        [StringLength(11, ErrorMessage = "مقدار وارد شده بیش 11 کارکتراست")]
        public string Mobile { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا مقدار را وارد نمایید")]
        [StringLength(100, ErrorMessage = "مقدار وارد شده بیش 100 کارکتراست")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //  [Remote("PasswordMatch", "Account", HttpMethod = "Post",ErrorMessage ="پسورد ها برابر نیست")]
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا مقدار را وارد نمایید")]
        [StringLength(100, ErrorMessage = "مقدار وارد شده بیش 100 کارکتراست")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "پسورد ها برابر نیست")]
        public string PasswordVerify { get; set; }
    }
}