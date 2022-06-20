using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Prime { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Img { get; set; }

        public decimal Gia { get; set; }

        public bool TrangThai { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Colour { get; set; }

        public int SoLuong { get; set; }

        public decimal Tong { get; set; }
        public string Mau { get; set; }
        public string Kich { get; set; }
        public decimal GiaNhap { get; set; }
    }
}