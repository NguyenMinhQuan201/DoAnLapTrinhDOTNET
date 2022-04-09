using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ThongTin
    {
        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string email { get; set; }
        [StringLength(50)]
        public int phone { get; set; }
    }
}