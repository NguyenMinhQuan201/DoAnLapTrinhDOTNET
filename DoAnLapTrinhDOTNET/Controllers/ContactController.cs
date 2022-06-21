using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLapTrinhDOTNET.Controllers
{
    public class ContactController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        // GET: Contact
        public ActionResult Index()
        {
            var lst = db.LienHes.ToList();
            return View(lst);
        }
    }
}