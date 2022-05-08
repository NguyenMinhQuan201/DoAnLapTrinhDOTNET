using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Shop.Controllers
{
    public class EventsController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        private static int M;
        // GET: Events
        public async Task<ActionResult> Index(int? page, int?id)
        {
            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams, "IDLoaiSanPham", "Ten");
            if (page == null) page = 1;
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            if (id != null)
            {
                var result = await db.SanPhams.Where(x=>x.IDLoaiSanPham==id).ToListAsync();
                return View((result.ToPagedList(pageNumber, pageSize)));
            }
            else
            {
                var result = await db.SanPhams.ToListAsync();
                return View((result.ToPagedList(pageNumber, pageSize)));
            }
        }
        public async Task<ActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                int Id = id.Value;
                M = id.Value;
                var dao = new EventsModels();
                ViewBag.MauSacSP = new SelectList(dao.ListAll(Id), "ID", "MauSacSP", 1);
                ViewBag.KichCoSP = new SelectList(dao.ListAllSize(Id), "ID", "KichCoSP", 1);
                
            }
            ChiTietSanPham chiTietSanPham  = await db.ChiTietSanPhams.Where(x=>x.IDSanPham==id).FirstOrDefaultAsync();
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSanPham);
        }
        
        public JsonResult onCheck(int id, int mau, int kich)
        {
            var fmau = db.MauSacs.Find(mau);
            var fkich = db.KichCoes.Find(kich);
            var find = db.ChiTietSanPhams.Where(x => x.IDSanPham==id&& x.KichCoSP==fkich.KichCoSP && x.MauSacSP==fmau.MauSacSP && x.SoLuong>0).FirstOrDefault();
            if (find == null)
            {
                return Json(new { status = false });
            }
            return Json(new { status = true });
        }
        public JsonResult onCheck2(int id, int mau, int kich)
        {
            var fmau = db.MauSacs.Find(mau);
            var fkich = db.KichCoes.Find(kich);
            var find = db.ChiTietSanPhams.Where(x => x.IDSanPham == id && x.KichCoSP == fkich.KichCoSP && x.MauSacSP == fmau.MauSacSP && x.SoLuong > 0).FirstOrDefault();
            if (find == null)
            {
                return Json(new { status = false });
            }
            return Json(new { status = true });
        }
        public JsonResult checkbysize(int kich)
        {
            List<MauSac> arr = new List<MauSac>();
            var fkich = db.KichCoes.Find(kich);
            var find = db.ChiTietSanPhams.Where(x => x.KichCoSP == fkich.KichCoSP).Select(x=>x.MauSacSP).ToList();
            foreach(var item in find)
            {
                var findmau = db.MauSacs.Where(x => x.MauSacSP == item).FirstOrDefault();
                var ha = new MauSac { ID = findmau.ID, MauSacSP = item };
                arr.Add(ha);
            }
            if (find == null)
            {
                return Json(new { status = false });
            }
            return Json(new { status = true,
                Arr=arr
            });
        }
        public JsonResult KiemTra(int id, int mau, int kich)
        {
            var fmau = db.MauSacs.Find(mau);
            var fkich = db.KichCoes.Find(kich);
            var find = db.ChiTietSanPhams.Where(x => x.IDSanPham == id && x.KichCoSP == fkich.KichCoSP && x.MauSacSP == fmau.MauSacSP && x.SoLuong > 0).FirstOrDefault();
            if (find == null)
            {
                return Json(new { status = false });
            }
            return Json(new
            {
                status = true,
            });
        }
        public ActionResult MoreToYou(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var find = db.SanPhams.Where(x=>x.IDSanPham==M).FirstOrDefault();
            var result =  db.SanPhams.Where(x => x.IDLoaiSanPham == find.IDLoaiSanPham).ToList();
            return PartialView((result.ToPagedList(pageNumber, pageSize)));
        }
    }
}