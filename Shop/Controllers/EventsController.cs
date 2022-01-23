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

namespace Shop.Controllers
{
    public class EventsController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        // GET: Events
        public async Task<ActionResult> Index()
        {
           /* if (page == null) page = 1;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
*/
            var result = await db.ChiTietSanPham.ToListAsync();
            return View(result);
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
    }
}