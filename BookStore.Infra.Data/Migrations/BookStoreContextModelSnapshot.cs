﻿// <auto-generated />
using System;
using BookStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Infra.Data.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookStore.Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = new Guid("50eea480-81c8-4387-84a6-0258f6607e4a"),
                            Name = "Autor1"
                        },
                        new
                        {
                            Id = new Guid("c9636af3-f5a9-4c30-ae21-9be184e11e02"),
                            Name = "Autor2"
                        },
                        new
                        {
                            Id = new Guid("4d0644a9-4db6-4f1a-8782-b3caa36a1b5a"),
                            Name = "Autor3"
                        });
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<int>("StockQty");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Book", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
