using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace DoAnLapTrinhDOTNET.Controllers
{
    public class SanPhamsController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();

        // GET: SanPhams
        public async Task<ActionResult> Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(await sanPhams.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams, "IDLoaiSanPham", "Ten");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDSanPham,Ten,IDLoaiSanPham,Images,Gia,Mota")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["image"];
                string path = Server.MapPath("~/UploadImg/" + f.FileName);
                f.SaveAs(path);
                ViewBag.FileName = f.FileName;
                ViewBag.Filetype = f.ContentType;
                ViewBag.Filesize = f.ContentLength;
                sanPham.Images = f.FileName;
                db.SanPhams.Add(sanPham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams, "IDLoaiSanPham", "Ten", sanPham.IDLoaiSanPham);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams, "IDLoaiSanPham", "Ten", sanPham.IDLoaiSanPham);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDSanPham,Ten,IDLoaiSanPham,Images,Gia,Mota")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["image"];
                string path = Server.MapPath("~/UploadImg/" + f.FileName);
                f.SaveAs(path);
                ViewBag.FileName = f.FileName;
                ViewBag.Filetype = f.ContentType;
                ViewBag.Filesize = f.ContentLength;
                sanPham.Images = f.FileName;
                db.Entry(sanPham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams, "IDLoaiSanPham", "Ten", sanPham.IDLoaiSanPham);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SanPham sanPham = await db.SanPhams.FindAsync(id);
            db.SanPhams.Remove(sanPham);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
