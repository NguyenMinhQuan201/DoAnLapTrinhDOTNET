using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DoAnLapTrinhDOTNET.Controllers
{
    public class NewsController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        // GET: News
        public ActionResult Index()
        {
            var lst = db.TinTucs.ToList();
            return View(lst);
        }

        // GET: TinTucs/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: TinTucs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["image"];
                string path = Server.MapPath("~/UploadImg/" + f.FileName);
                f.SaveAs(path);
                ViewBag.FileName = f.FileName;
                ViewBag.Filetype = f.ContentType;
                ViewBag.Filesize = f.ContentLength;
                tinTuc.Image = f.FileName;
                tinTuc.CreatedDate = DateTime.UtcNow;
                db.TinTucs.Add(tinTuc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tinTuc);
        }
    }
}