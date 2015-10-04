using System.ComponentModel.DataAnnotations;

namespace CPro.Areas.AdminCPro.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhập tên tài khoản",AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}