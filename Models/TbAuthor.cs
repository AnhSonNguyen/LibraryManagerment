using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagerment.Models
{
    public partial class TbAuthor
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên tác giả")]
        public string AuthorName { get; set; } = null!;
        public string? Description { get; set; }        
    }
}
