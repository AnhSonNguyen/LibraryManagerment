using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerment.Models;

public partial class QltvthttContext : DbContext
{
    public QltvthttContext()
    {
    }

    public QltvthttContext(DbContextOptions<QltvthttContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=ADMIN-PC\\SQLEXPRESS; initial catalog=QLTVTHTT; integrated security=True; \nTrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("tb_Menu");

            entity.Property(e => e.MenuId)
                .HasColumnName("MenuId");

            entity.Property(e => e.Title)
                .HasMaxLength(150);

            entity.Property(e => e.Alias)
                .HasMaxLength(150);

            entity.Property(e => e.Description)
                .HasMaxLength(500);

            entity.Property(e => e.Levels);

            entity.Property(e => e.ParentId)
                .HasColumnName("ParentId");

            entity.Property(e => e.Position);

            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150);

            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150);

            entity.Property(e => e.IsActive);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
