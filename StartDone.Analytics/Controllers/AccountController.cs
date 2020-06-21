using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;
using StartDone.Analytics.Models.Domian;
using StartDone.Analytics.Models.ViewModels;
using StartDone.Analytics.Models.Repository;

namespace StartDone.Analytics.Controllers
{
    public class AccountController : Controller
    {
        private static readonly StartDone_AnalyticsEntities db = new StartDone_AnalyticsEntities();

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Dashboard");

            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Model_Login model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Dashboard");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.State = "Error";

                return View("Login", model);

            }
            var q = db.Tbl_User.Where(a => a.User_Mobile == model.Username).SingleOrDefault();

            if (q == null)
            {
                TempData["TosterState"] = "error";
                TempData["TosterType"] = TosterType.Maseage;
                TempData["TosterMassage"] = "کاربر یافت نشد !";

                return View();
            }


            var SaltPassword = model.Password + q.User_PasswordSalt;
            var SaltPasswordBytes = Encoding.UTF8.GetBytes(SaltPassword);
            var SaltPasswordHush = Convert.ToBase64String(SHA512.Create().ComputeHash(SaltPasswordBytes));


            if (q.User_PasswordHash == SaltPasswordHush)
            {
                string s = string.Empty;

                s = Rep_UserRole.Get_RoleNameWithID(q.User_RoleID);

                var Ticket = new FormsAuthenticationTicket(0, model.Username, DateTime.Now, model.RemenberMe ? DateTime.Now.AddDays(30) : DateTime.Now.AddDays(1), true, s);
                var EncryptedTicket = FormsAuthentication.Encrypt(Ticket);
                var Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncryptedTicket)
                {
                    Expires = Ticket.Expiration
                };
                Response.Cookies.Add(Cookie);

                TempData["TosterState"] = "success";
                TempData["TosterType"] = TosterType.Maseage;
                TempData["TosterMassage"] = "خوش آمدید";

                return RedirectToAction("index", "Dashboard");
            }
            else
            {
                TempData["TosterState"] = "error";
                TempData["TosterType"] = TosterType.Maseage;
                TempData["TosterMassage"] = "پسورد نادرست است !";

                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            var Cookie = new HttpCookie(FormsAuthentication.FormsCookieName)
            {
                Expires = DateTime.Now.AddDays(-1)
            };

            Response.Cookies.Add(Cookie);
            Session.RemoveAll();

            return RedirectToAction("Login", "Account");
        }

        //[Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public ActionResult Register()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Login");

            //}
            return View();
        }
        //[Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult Register(Model_Register model)
        {

            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            Tbl_User _User = new Tbl_User();

            _User.User_Name = model.Name;
            _User.User_Family = model.Family;
            _User.User_Mobile = model.Mobile;
            _User.User_RoleID = 1;
            _User.User_CreateDate = DateTime.Now;

            var Salt = Guid.NewGuid().ToString("N");
            var SaltPassword = model.Password + Salt;
            var SaltPasswordBytes = Encoding.UTF8.GetBytes(SaltPassword);
            var SaltPasswordHush = Convert.ToBase64String(SHA512.Create().ComputeHash(SaltPasswordBytes));

            _User.User_PasswordHash = SaltPasswordHush;
            _User.User_PasswordSalt = Salt;

            db.Tbl_User.Add(_User);


            if (Convert.ToBoolean(db.SaveChanges() > 0))
            {
                TempData["TosterState"] = "success";
                TempData["TosterType"] = TosterType.Maseage;
                TempData["TosterMassage"] = "ثبت نام با موفقیت انجام شده";

                return RedirectToAction("Login");
            }
            else
            {
                TempData["TosterState"] = "error";
                TempData["TosterType"] = TosterType.Maseage;
                TempData["TosterMassage"] = "خطا";

                return View();
            }
        }


    }
}