using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Models.Framework;
using System.Net.Http;
using System.Web;

namespace DoAnLapTrinhDOTNET.ServiceAPI
{
    public interface IServiceAPI
    {
        Task<List<LoaiSanPham>> GetLoaiSanPham();
    }
    public class ServiceAPI : IServiceAPI
    {
        public async Task<List<LoaiSanPham>> GetLoaiSanPham()
        {
            string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + "localhost:44314" +
                HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";   // Lấy base uri của website
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