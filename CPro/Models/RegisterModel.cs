using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using Microsoft.AspNet.Identity;

namespace CPro.Models
{
    public class RegisterModel
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Nhập tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
        public string PassWord { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("PassWord",ErrorMessage = "Mật khẩu không trùng nhau")]
        public string ConfirmPassWord { get; set; }


        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
    }
}