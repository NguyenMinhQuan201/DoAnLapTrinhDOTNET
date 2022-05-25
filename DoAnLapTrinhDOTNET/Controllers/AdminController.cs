using DoAnLapTrinhDOTNET.Common;
using DoAnLapTrinhDOTNET.Models;
using DoAnLapTrinhDOTNET.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if (i == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var a = await _api.Authenticate(model);
                i = 1;
                return RedirectToAction("Index", "Home", new { UserName = model.UserName });
            }
            else
            {
                ModelState.AddModelError("", "ten dang nhap hoac mat khau ko dung");
            }
            return View(model);
        }
        /*public JsonResult Gettoken(string token)
        {
            if (token != "")
            {
                Encryptor.GetToken = token;
                return Json(new { status = true });
            }
            return Json(new { status = false });
        }*/
        public JsonResult Gettoken(string token)
        {
            Response.Cookies["token"].Value = token;
            Response.Cookies["token"].Name = "token";
            HttpCookie cook = Request.Cookies["token"];
            if (cook == null)
            {
                return Json(new { status = false });
            }
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            i = 0;
            return RedirectToAction("Index", "Admin");
        }
    }
}