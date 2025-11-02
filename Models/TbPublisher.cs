using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagerment.Models
{
    public partial class TbPublisher
    {
        public int PublisherId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên nhà phát hành")]
        public string PublisherName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
