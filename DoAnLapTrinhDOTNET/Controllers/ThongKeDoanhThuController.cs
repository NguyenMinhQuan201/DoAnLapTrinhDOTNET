using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLapTrinhDOTNET.Controllers
{
    public class ThongKeDoanhThuController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        // GET: ThongKeDoanhThu
        public ActionResult Index()
        {
            var lst = db.HoaDons.ToList();
            return View(lst);
        }
    }
}