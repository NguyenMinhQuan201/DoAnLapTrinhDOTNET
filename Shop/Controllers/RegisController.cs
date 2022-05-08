
using Models.UserRegistration;
using Shop.Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLapTrinhDOTNET.Common;

namespace Shop.Controllers
{
    public class RegisController : Controller
    {
        // GET: Regis
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserRegis model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserRegisDao();
                if (dao.CheckUserName(model.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var user = new NguoiDung();
                    user.UserName = model.Username;
                    user.PassWord = model.Password;
                    user.Email = model.Email;
                    //model.Password = Encryptor.MD5Hash(model.Password);

                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new UserRegis();
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return RedirectToAction("Index", "Regis");
        }
    }
}