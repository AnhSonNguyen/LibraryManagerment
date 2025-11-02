using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagerment.Models
{
    public partial class TbAccount
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }


        public virtual TbRole? Role { get; set; }
    }
}
