namespace ModelCPro.EntityFrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

      
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [StringLength(32, ErrorMessage = "{0} ít nhất {2} ký tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(20)]
        [Display(Name = "Nhóm người dùng")]
        [Required(ErrorMessage = "Nhập nhóm người dùng")]
        public string GroupID { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Nhập Email")]
        public string Email { get; set; }
        
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        
        public string CreatedBy { get; set; }
       
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
