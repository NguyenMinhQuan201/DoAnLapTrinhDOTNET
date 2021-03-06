using Models.Framework;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private LipstickDbContext db = new LipstickDbContext();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        private void makeDetail(string cartUser, int orderID)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<Order>>(cartUser);
            var findOrder = db.HoaDons.Where(x => x.IDHoaDon == orderID).FirstOrDefault();
            
            int i = 0;
            foreach (var item in jsoncart)
            {
                i = i + 1;
                var orderDetail = new ChiTietHoaDon()
                {
                    IDHoaDon = findOrder.IDHoaDon,
                    Gia = item.Gia,
                    Images = item.Img,
                    MauSacSP = item.Mau,
                    KichCoSP = item.Kich,
                    Soluong = item.SoLuong,
                };
                db.ChiTietHoaDons.Add(orderDetail);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public JsonResult MakeOrder(string cartUser, string addRess, int phone)
        {
            try
            {
                var jsoncart = new JavaScriptSerializer().Deserialize<List<Order>>(cartUser);
                List<decimal> GiaNhap=new List<decimal>();
                decimal tong = 0;
                decimal tonggianhap = 0;
                foreach (var item in jsoncart)
                {
                    tong = tong + (decimal)item.Tong;
                    var findGiaNhapById = db.ChiTietSanPhams.Find(item.Prime);
                    tonggianhap = tonggianhap + (decimal)findGiaNhapById.GiaNhap*item.SoLuong;
                }
                
                var order = new HoaDon()
                {
                    TongGiaNhap=tonggianhap,
                    Gia = tong,
                    SDT = phone,
                    DiaChi = addRess,
                    NgayGio = DateTime.UtcNow
                };
                db.HoaDons.Add(order);
                db.SaveChanges();
                makeDetail(cartUser, order.IDHoaDon);
                return Json(new { status = true });
            }
            catch (Exception)
            {
                Console.WriteLine("Lỗi");
                return Json(new { status = false });
            }
        }
        public JsonResult MakeOrderPaypal(string cartUser, string thongtin)
        {
            try
            {
                var jsoncart = new JavaScriptSerializer().Deserialize<List<Order>>(cartUser);
                var jsonOrder = new JavaScriptSerializer().Deserialize<List<ThongTin>>(thongtin);
                List<decimal> GiaNhap = new List<decimal>();
                decimal tong = 0;
                decimal tonggianhap = 0;
                foreach (var item in jsoncart)
                {
                    tong = tong + (decimal)item.Tong;
                    var findGiaNhapById = db.ChiTietSanPhams.Find(item.Prime);
                    tonggianhap = tonggianhap + (decimal)findGiaNhapById.GiaNhap * item.SoLuong;
                }

                var order = new HoaDon()
                {
                    TongGiaNhap=tonggianhap,
                    Gia = tong,
                    SDT = jsonOrder[0].phone,
                    DiaChi = jsonOrder[0].address,
                    NgayGio = DateTime.UtcNow
                };
                db.HoaDons.Add(order);
                db.SaveChanges();
                makeDetail(cartUser, order.IDHoaDon);
                return Json(new { status = true });
            }
            catch (Exception)
            {
                Console.WriteLine("loi");
                return Json(new { status = false });
            }
        }
    }
}