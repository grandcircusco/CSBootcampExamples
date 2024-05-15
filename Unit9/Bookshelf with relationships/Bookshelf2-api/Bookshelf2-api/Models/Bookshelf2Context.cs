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

            // Modified to remove the BookOwners list from User
            entity.HasOne(d => d.LentOutTo).WithMany()
                .HasForeignKey(d => d.LentOutToId)
                .HasConstraintName("FK__Book__lentOutToI__5070F446");

            // Modified to remove the BookLentOutTos list from User
            // Also modified to remove the Owner property from Book
            entity.HasOne<User>().WithMany()
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Book__ownerId__4F7CD00D");

            // Add sample data to the database for this demo
            entity.HasData(
                new Book() { Id = 1, Title = "Pride and Prejudice", Author = "Jane Austen", Pages = 432, LentOut = false, OwnerId = 1 },
                new Book() { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Pages = 281, LentOut = true, OwnerId = 1, LentOutToId = 2 },
                new Book() { Id = 3, Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", Pages = 448, LentOut = true, OwnerId = 1, LentOutToId = 4 },
                new Book() { Id = 4, Title = "In Cold Blood", Author = "Truman Capote", Pages = 368, LentOut = false, OwnerId = 1 },
                new Book() { Id = 5, Title = "The Adventures of Tom Sawyer", Author = "Mark Twain", Pages = 308, LentOut = true, OwnerId = 1, LentOutToId = 3 },
                new Book() { Id = 6, Title = "The Adventures of Huckleberry Finn", Author = "Mark Twain", Pages = 366, LentOut = false, OwnerId = 1 },
                new Book() { Id = 7, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Pages = 192, LentOut = false, OwnerId = 2 },
                new Book() { Id = 8, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Pages = 492, LentOut = true, OwnerId = 2, LentOutToId = 1 },
                new Book() { Id = 9, Title = "In Cold Blood", Author = "Truman Capote", Pages = 368, LentOut = true, OwnerId = 2, LentOutToId = 3 },
                new Book() { Id = 10, Title = "Brave New World", Author = "Aldous Huxley", Pages = 288, LentOut = false, OwnerId = 2 }
            );
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

            // Add sample data to the database for this demo
            entity.HasData(
                new User() { Id = 1, Username = "orville", DisplayName = "Orville Wright" },
                new User() { Id = 2, Username = "amelia", DisplayName = "Amelia Earhart" },
                new User() { Id = 3, Username = "bessie", DisplayName = "Bessie Coleman" },
                new User() { Id = 4, Username = "charles", DisplayName = "Charles Lindbergh" }
            );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    
}
