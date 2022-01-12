using DoAnLapTrinhDOTNET.Common;
using DoAnLapTrinhDOTNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DoAnLapTrinhDOTNET.Controllers
{
    public class AdminController : Controller
    {
        private static int i;
        // GET: AdminLogin
        [HttpGet]
        public ActionResult Index()
        {
            if (i==1)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdminLoginModel model)
        {
            
            if (Membership.ValidateUser(model.UserName, Encryptor.MD5Hash(model.PassWord)) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.Remember);
                i = 1;
                return RedirectToAction("Index", "Home", new { UserName = model.UserName });
            }
            else
            {
                ModelState.AddModelError("", "ten dang nhap hoac mat khau ko dung");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            i = 0;
            return RedirectToAction("Index", "Admin");
        }
    }
}