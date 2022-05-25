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
using DoAnLapTrinhDOTNET.service;

namespace DoAnLapTrinhDOTNET.Controllers
{
    public class LoaiSanPhamsController : Controller
    {
        private LipstickDbContext db;
        private IServiceApi _api;
        public LoaiSanPhamsController(IServiceApi api)
        {
            db = new LipstickDbContext();
            _api = api;
        }

        // GET: LoaiSanPhams
        public async Task<ActionResult> Index()
        {
            HttpCookie cook = Request.Cookies["token"];
            ViewBag.Title = "Home Page";
            var list = await _api.GetAllLoaiSanPham(cook.Value);
            if (list != null) // Nếu list user khác null thì trả về View có chứa list
                return View(list);
            return View();
        }

        // GET: LoaiSanPhams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDLoaiSanPham,Ten,Alias,TrangThai")] LoaiSanPham loaiSanPham)
        {
            HttpCookie cook = Request.Cookies["token"];
            if (ModelState.IsValid)
            {
                var check = await _api.PostLoaiSanPham(loaiSanPham, cook.Value);
                /*db.LoaiSanPhams.Add(loaiSanPham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");*/
                return RedirectToAction("Index");
            }

            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: LoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDLoaiSanPham,Ten,Alias,TrangThai")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSanPham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            db.LoaiSanPhams.Remove(loaiSanPham);
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
