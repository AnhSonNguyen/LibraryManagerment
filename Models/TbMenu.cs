using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagerment.Models
{
    public partial class TbMenu
    {
        public int MenuId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên menu")]
        public string? Title { get; set; } = null!;
        [Required(ErrorMessage = "Vui lòng nhập tên miền địa chỉ")]
        public string? Alias { get; set; } = null!;
        public string? Description { get; set; }
        public int? Levels { get; set; }
        public int? ParentId { get; set; }
        public int? Position { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
