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
        public virtual DbSet<TbCategory> TbCategories { get; set; } 

        public virtual DbSet<TbAccount> TbAccounts { get; set; }
        public virtual DbSet<TbAuthor> TbAuthors { get; set; }
        public virtual DbSet<TbRole> TbRoles { get; set; }
        public virtual DbSet<TbPublisher> TbPublishers { get; set; }
        public virtual DbSet<TbBook> TbBooks { get; set; }
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
            modelBuilder.Entity<TbAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId);
                entity.ToTable("tb_Account");

                entity.Property(e => e.Username).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.FullName).HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.LastLogin).HasColumnType("datetime");
            });
            modelBuilder.Entity<TbAuthor>(entity =>
            {
                entity.HasKey(e => e.AuthorId);
                entity.ToTable("tb_Author");

                entity.Property(e => e.AuthorName).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
            });
            modelBuilder.Entity<TbRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.ToTable("tb_Role");

                entity.Property(e => e.RoleName).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
            });
            modelBuilder.Entity<TbPublisher>(entity =>
            {
                entity.HasKey(e => e.PublisherId);
                entity.ToTable("tb_Publisher");
                entity.Property(e => e.PublisherName).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
            });
            modelBuilder.Entity<TbBook>(entity =>
            {
                entity.HasKey(e => e.BookId);
                entity.ToTable("tb_Book");

                entity.Property(e => e.Title).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Image).HasMaxLength(500);
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.ModifiedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });
        }
    }
}
