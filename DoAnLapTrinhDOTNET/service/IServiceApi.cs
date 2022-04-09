using DoAnLapTrinhDOTNET.Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLapTrinhDOTNET.service
{
    public interface IServiceApi
    {
        Task<List<LoaiSanPham>> GetAllLoaiSanPham();
        Task<string> Authenticate(AdminLoginModel request);
        Task<bool> PostLoaiSanPham(LoaiSanPham loaiSanPham);
    }
}
