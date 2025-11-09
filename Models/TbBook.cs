using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagerment.Models
{
    public partial class TbBook
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tiêu đề sách")]
        [StringLength(250, ErrorMessage = "Tiêu đề không vượt quá 250 ký tự")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng chọn tác giả")]
        public int? AuthorId { get; set; } 

        [Required(ErrorMessage = "Vui lòng chọn nhà xuất bản")]
        public int? PublisherId { get; set; }

        [StringLength(1000, ErrorMessage = "Mô tả không vượt quá 1000 ký tự")]
        public string? Description { get; set; }

        [StringLength(500, ErrorMessage = "Tên file ảnh không vượt quá 500 ký tự")]
        public string? Image { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải >= 0")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn thể loại")]
        public int? CategoryId { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public virtual TbAuthor? Author { get; set; }
        public virtual TbPublisher? Publisher { get; set; }
        public virtual TbCategory? Category { get; set; }
    }
}
