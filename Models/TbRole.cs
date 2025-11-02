using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagerment.Models
{
    public partial class TbRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
