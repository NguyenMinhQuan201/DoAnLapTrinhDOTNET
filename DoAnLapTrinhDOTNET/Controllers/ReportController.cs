using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLapTrinhDOTNET.Controllers
{
    public class ReportController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        // GET: Report
        public ActionResult Index()
        {
            var lst = db.HoaDons.ToList();
            return View(lst);
        }
    }
}