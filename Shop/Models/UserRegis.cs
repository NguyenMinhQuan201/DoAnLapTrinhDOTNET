using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class UserRegis
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Độ dài mật khẩu ít nhất 3 kí tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }

        /*[Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }*/

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập email")]
        public string Email { get; set; }
    }
}