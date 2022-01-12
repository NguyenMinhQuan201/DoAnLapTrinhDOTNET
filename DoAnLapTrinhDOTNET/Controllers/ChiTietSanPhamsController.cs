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
    public class ChiTietSanPhamsController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();

        // GET: ChiTietSanPhams
        public async Task<ActionResult> Index()
        {
            var chiTietSanPhams = db.ChiTietSanPhams.Include(c => c.SanPham);
            return View(await chiTietSanPhams.ToListAsync());
        }

        // GET: ChiTietSanPhams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = await db.ChiTietSanPhams.FindAsync(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.IDSanPham = new SelectList(db.ChiTietSanPham, "IDSanPham", "Ten");
            return View();
        }

        // POST: ChiTietSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,IDSanPham,Ten,IDLoaiSanPham,Images,Gia,Mota,MauSacSP,KichCoSP,SoLuong,LuotXem")] ChiTietSanPham chiTietSanPham)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietSanPhams.Add(chiTietSanPham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDSanPham = new SelectList(db.ChiTietSanPham, "IDSanPham", "Ten", chiTietSanPham.IDSanPham);
            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = await db.ChiTietSanPhams.FindAsync(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDSanPham = new SelectList(db.ChiTietSanPham, "IDSanPham", "Ten", chiTietSanPham.IDSanPham);
            return View(chiTietSanPham);
        }

        // POST: ChiTietSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,IDSanPham,Ten,IDLoaiSanPham,Images,Gia,Mota,MauSacSP,KichCoSP,SoLuong,LuotXem")] ChiTietSanPham chiTietSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietSanPham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDSanPham = new SelectList(db.ChiTietSanPham, "IDSanPham", "Ten", chiTietSanPham.IDSanPham);
            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSanPham chiTietSanPham = await db.ChiTietSanPhams.FindAsync(id);
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSanPham);
        }

        // POST: ChiTietSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChiTietSanPham chiTietSanPham = await db.ChiTietSanPhams.FindAsync(id);
            db.ChiTietSanPhams.Remove(chiTietSanPham);
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
