using Microsoft.EntityFrameworkCore;

namespace LibraryManagerment.Models
{
    public partial class QltvthttContext : DbContext
    {
        public QltvthttContext(DbContextOptions<QltvthttContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbMenu> TbMenus { get; set; }
        public virtual DbSet<TbCategory> TbCategories { get; set; }  // 👈 thêm dòng này

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình bảng Menu
            modelBuilder.Entity<TbMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);
                entity.ToTable("tb_Menu");

                entity.Property(e => e.Title).HasMaxLength(150);
                entity.Property(e => e.Alias).HasMaxLength(150);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CreatedBy).HasMaxLength(150);
                entity.Property(e => e.ModifiedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            // 👇 Thêm cấu hình cho bảng Category
            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.ToTable("tb_Category");

                entity.Property(e => e.Title).HasMaxLength(150);
                entity.Property(e => e.Alias).HasMaxLength(150);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.ModifiedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });
        }
    }
}
