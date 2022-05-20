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
using System.Net.Http;
using System.Net.Http.Headers;
using DocumentFormat.OpenXml.Bibliography;
using DoAnLapTrinhDOTNET.Models;
using Newtonsoft.Json;
using System.Text;
using DoAnLapTrinhDOTNET.Common;
using Azure;

namespace DoAnLapTrinhDOTNET.service
{
    public class ServiceApi : IServiceApi
    {
        public async Task<List<LoaiSanPham>> GetAllLoaiSanPham()
        {
            string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + "localhost:44314" +
                HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";   // Lấy base uri của website
            using (var httpClient = new HttpClient())
            {
                var token = Encryptor.GetToken;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
        public async Task<bool> PostLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + "localhost:44314" +
                HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";   // Lấy base uri của website
            using (var httpClient = new HttpClient())
            {
                var token = Encryptor.GetToken;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage res = await httpClient.PostAsJsonAsync(baseUrl + "api/LoaiSanPhams/PostLoaiSanPham", loaiSanPham);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<string> Authenticate(AdminLoginModel request)
        {
            string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + "localhost:44314" +
                HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";   // Lấy base uri của website

            var b = new AdminLoginModel()
            {

                UserName = request.UserName,
                Password = Encryptor.MD5Hash(request.Password),
                grant_type = "password",
            };
            var json = JsonConvert.SerializeObject(b);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage res = await httpClient.PostAsJsonAsync(baseUrl + "token", b);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string a = res.Content.ReadAsAsync<string>().Result;
                    return a;
                }
                return null;
            }
           

        }
    }
}