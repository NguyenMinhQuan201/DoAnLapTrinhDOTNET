using DoAnLapTrinhDOTNET.Common;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin model)
        {
            if (Membership.ValidateUser(model.Username, Encryptor.MD5Hash(model.Password)) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.Remember);

                HttpContext.User.Identity.Name.Contains(model.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}