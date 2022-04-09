using DoAnLapTrinhDOTNET.Common;
using DoAnLapTrinhDOTNET.Models;
using DoAnLapTrinhDOTNET.service;
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
        private IServiceApi _api;
        public AdminController(IServiceApi api)
        {
            _api = api;
        }
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
            
            if (Membership.ValidateUser(model.UserName, model.Password) && ModelState.IsValid)
            {
                var token = _api.Authenticate(model);
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
        public JsonResult Gettoken(string token)
        {
            if (token != "")
            {
                Encryptor.GetToken=token;
                return Json(new { status = true });
            }
            return Json(new { status = false });
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            i = 0;
            return RedirectToAction("Index", "Admin");
        }
    }
}