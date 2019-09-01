using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using BookStore.Infra.Data.Mappings;
using BookStore.Infra.Data.Extensions;
using System;

namespace BookStore.Infra.Data.Context
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }        

        public BookStoreContext(DbContextOptions options) : 
            base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new BookMapping());
            modelBuilder.AddConfiguration(new AuthorMapping());

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = Guid.NewGuid(), Name = "Autor1" });

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = Guid.NewGuid(), Name = "Autor2" });

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = Guid.NewGuid(), Name = "Autor3" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
