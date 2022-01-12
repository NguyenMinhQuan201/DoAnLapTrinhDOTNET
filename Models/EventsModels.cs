using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EventsModels
    {
        private LipstickDbContext _context = null;
        public EventsModels()
        {
            _context = new LipstickDbContext();
        }
        public List<MauSac> ListAll(int id)
        {
            List<MauSac> a = new List<MauSac>();
            var find = _context.ChiTietSanPhams.Where(x => x.IDSanPham == id).ToList();
            var result = _context.MauSacs.ToList();
            foreach (var item in find)
            {
                foreach(var item2 in result)
                {
                    if (a.Contains(item2))
                    {
                        int i = 0;
                    }
                    else
                    {
                        if (item.MauSacSP == item2.MauSacSP)
                        {
                            a.Add(item2);
                        }
                    }
                }
            }
           
            return a;
        }
        public List<KichCo> ListAllSize(int id)
        {
            List<KichCo> a = new List<KichCo>();
            var find = _context.ChiTietSanPhams.Where(x => x.IDSanPham == id).ToList();
            var result = _context.KichCoes.ToList();
            foreach (var item in find)
            {
                foreach (var item2 in result)
                {
                    if (a.Contains(item2))
                    {
                        int i = 0;
                    }
                    else
                    {
                        if (item.KichCoSP == item2.KichCoSP)
                        {
                            a.Add(item2);
                        }
                    }
                }
            }

            return a;
        }
    }
}
