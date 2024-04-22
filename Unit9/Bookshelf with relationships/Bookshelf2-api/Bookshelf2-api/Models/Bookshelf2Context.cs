using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf2_api.Models;

public partial class Bookshelf2Context : DbContext
{
    public Bookshelf2Context()
    {
    }

    public Bookshelf2Context(DbContextOptions<Bookshelf2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Bookshelf2; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Book__3213E83F56B36CA8");

            entity.ToTable("Book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(80)
                .HasColumnName("author");
            entity.Property(e => e.LentOut).HasColumnName("lentOut");
            entity.Property(e => e.LentOutToId).HasColumnName("lentOutToId");
            entity.Property(e => e.OwnerId).HasColumnName("ownerId");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.Title)
                .HasMaxLength(80)
                .HasColumnName("title");

            entity.HasOne(d => d.LentOutTo).WithMany(p => p.BookLentOutTos)
                .HasForeignKey(d => d.LentOutToId)
                .HasConstraintName("FK__Book__lentOutToI__5070F446");

            entity.HasOne(d => d.Owner).WithMany(p => p.BookOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Book__ownerId__4F7CD00D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FF03ADD68");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .HasColumnName("displayName");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
