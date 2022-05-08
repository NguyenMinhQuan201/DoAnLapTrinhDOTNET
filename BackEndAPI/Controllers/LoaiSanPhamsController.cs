using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Models.Framework;

namespace BackEndAPI.Controllers
{
    [RoutePrefix("api/LoaiSanPhams")]
    public class LoaiSanPhamsController : ApiController
    {

        private LipstickDbContext db = new LipstickDbContext();

        // GET: api/LoaiSanPhams
        [Route("daubuoi")]
        [HttpGet]
        public IEnumerable<LoaiSanPham> GetLoaiSanPhams()
        {
            var result = db.LoaiSanPhams.ToList();
            return result;
        }

        // GET: api/LoaiSanPhams/5
        [ResponseType(typeof(LoaiSanPham))]
        public async Task<IHttpActionResult> GetLoaiSanPham(int id)
        {
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return Ok(loaiSanPham);
        }

        // PUT: api/LoaiSanPhams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLoaiSanPham(int id, LoaiSanPham loaiSanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaiSanPham.IDLoaiSanPham)
            {
                return BadRequest();
            }

            db.Entry(loaiSanPham).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSanPhamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LoaiSanPhams
        [ResponseType(typeof(LoaiSanPham))]
        public async Task<IHttpActionResult> PostLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoaiSanPhams.Add(loaiSanPham);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = loaiSanPham.IDLoaiSanPham }, loaiSanPham);
        }

        // DELETE: api/LoaiSanPhams/5
        [ResponseType(typeof(LoaiSanPham))]
        public async Task<IHttpActionResult> DeleteLoaiSanPham(int id)
        {
            LoaiSanPham loaiSanPham = await db.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            db.LoaiSanPhams.Remove(loaiSanPham);
            await db.SaveChangesAsync();

            return Ok(loaiSanPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoaiSanPhamExists(int id)
        {
            return db.LoaiSanPhams.Count(e => e.IDLoaiSanPham == id) > 0;
        }
    }
}