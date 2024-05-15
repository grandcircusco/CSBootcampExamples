﻿// <auto-generated />
using System;
using Bookshelf2_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookshelf2_api.Migrations
{
    [DbContext(typeof(Bookshelf2Context))]
    [Migration("20240515175716_CreateBookShelfDB")]
    partial class CreateBookShelfDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bookshelf2_api.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("author");

                    b.Property<bool?>("LentOut")
                        .HasColumnType("bit")
                        .HasColumnName("lentOut");

                    b.Property<int?>("LentOutToId")
                        .HasColumnType("int")
                        .HasColumnName("lentOutToId");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("ownerId");

                    b.Property<int?>("Pages")
                        .HasColumnType("int")
                        .HasColumnName("pages");

                    b.Property<string>("Title")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__Book__3213E83F56B36CA8");

                    b.HasIndex("LentOutToId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Book", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Jane Austen",
                            LentOut = false,
                            OwnerId = 1,
                            Pages = 432,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            LentOut = true,
                            LentOutToId = 2,
                            OwnerId = 1,
                            Pages = 281,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Gabriel García Márquez",
                            LentOut = true,
                            LentOutToId = 4,
                            OwnerId = 1,
                            Pages = 448,
                            Title = "One Hundred Years of Solitude"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Truman Capote",
                            LentOut = false,
                            OwnerId = 1,
                            Pages = 368,
                            Title = "In Cold Blood"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Mark Twain",
                            LentOut = true,
                            LentOutToId = 3,
                            OwnerId = 1,
                            Pages = 308,
                            Title = "The Adventures of Tom Sawyer"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Mark Twain",
                            LentOut = false,
                            OwnerId = 1,
                            Pages = 366,
                            Title = "The Adventures of Huckleberry Finn"
                        },
                        new
                        {
                            Id = 7,
                            Author = "F. Scott Fitzgerald",
                            LentOut = false,
                            OwnerId = 2,
                            Pages = 192,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Fyodor Dostoevsky",
                            LentOut = true,
                            LentOutToId = 1,
                            OwnerId = 2,
                            Pages = 492,
                            Title = "Crime and Punishment"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Truman Capote",
                            LentOut = true,
                            LentOutToId = 3,
                            OwnerId = 2,
                            Pages = 368,
                            Title = "In Cold Blood"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Aldous Huxley",
                            LentOut = false,
                            OwnerId = 2,
                            Pages = 288,
                            Title = "Brave New World"
                        });
                });

            modelBuilder.Entity("Bookshelf2_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("displayName");

                    b.Property<string>("Username")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK__User__3213E83FF03ADD68");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayName = "Orville Wright",
                            Username = "orville"
                        },
                        new
                        {
                            Id = 2,
                            DisplayName = "Amelia Earhart",
                            Username = "amelia"
                        },
                        new
                        {
                            Id = 3,
                            DisplayName = "Bessie Coleman",
                            Username = "bessie"
                        },
                        new
                        {
                            Id = 4,
                            DisplayName = "Charles Lindbergh",
                            Username = "charles"
                        });
                });

            modelBuilder.Entity("Bookshelf2_api.Models.Book", b =>
                {
                    b.HasOne("Bookshelf2_api.Models.User", "LentOutTo")
                        .WithMany()
                        .HasForeignKey("LentOutToId")
                        .HasConstraintName("FK__Book__lentOutToI__5070F446");

                    b.HasOne("Bookshelf2_api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK__Book__ownerId__4F7CD00D");

                    b.Navigation("LentOutTo");
                });
#pragma warning restore 612, 618
        }
    }
}
