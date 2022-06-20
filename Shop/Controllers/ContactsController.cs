using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using Models.SendContact;
using Shop.Models;

namespace Shop.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDao();
                var contactt = new LienHe();
                contactt.Name = model.Name;
                contactt.Email = model.Email;
                contactt.Mess = model.Mess;


                var result = dao.Insert(contactt);
                if (result > 0)
                {
                    ViewBag.Success = "Gửi thành công";
                    model = new Contact();
                    return RedirectToAction("Index", "Contacts");
                }
                else
                {
                    ModelState.AddModelError("", "Gửi không thành công");
                }
            }
            return RedirectToAction("Index", "Contacts");
        }
    }
}