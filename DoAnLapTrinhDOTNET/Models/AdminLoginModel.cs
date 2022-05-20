using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnLapTrinhDOTNET.Models
{
    public class AdminLoginModel
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
        public string grant_type { get; set; }
    }
}