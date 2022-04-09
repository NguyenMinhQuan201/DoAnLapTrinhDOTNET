using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BackEndAPI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";
            var list = await GetLoaiSanPham();
            if (list != null) // Nếu list user khác null thì trả về View có chứa list
                return View(list);
            return View();
        }
        private async Task<List<LoaiSanPham>> GetLoaiSanPham()   // Hàm Gọi API trả về list user
        {   
            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                Request.ApplicationPath.TrimEnd('/') + "/";   // Lấy base uri của website
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage res = await httpClient.GetAsync(baseUrl + "api/LoaiSanPhams/daubuoi");
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<LoaiSanPham> list = new List<LoaiSanPham>();
                    list = res.Content.ReadAsAsync<List<LoaiSanPham>>().Result;
                    return list;
                }
                return null;
            }
        }
    }
}
