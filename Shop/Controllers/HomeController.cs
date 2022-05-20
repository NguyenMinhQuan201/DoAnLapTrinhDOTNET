using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        private static string M;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductsHot(/*int? page*/)
        {
            /*if (page == null) page = 1;
            int pageSize = 4;
            int pageNumber = (page ?? 1);*/

            /*var find = db.SanPhams.Where(x => x.Mota == M).FirstOrDefault();
            var lst = db.SanPhams.Where(x => x.Mota == find.Mota).ToList();*/
            var lst = db.SanPhams.ToList();
            return PartialView(lst);
        }
        public ActionResult News(/*int? page*/)
        {
            /*if (page == null) page = 1;
            int pageSize = 4;
            int pageNumber = (page ?? 1);*/

            /*var find = db.SanPhams.Where(x => x.Mota == M).FirstOrDefault();
            var lst = db.SanPhams.Where(x => x.Mota == find.Mota).ToList();*/
            /*var lst = db.SanPhams.ToList();*/
            return PartialView();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}