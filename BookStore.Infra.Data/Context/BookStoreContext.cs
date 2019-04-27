using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using BookStore.Infra.Data.Mappings;
using BookStore.Infra.Data.Extensions;

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

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")))
        //    {
        //        var config = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();

        //        optionsBuilder.UseSqlServer(config.GetConnectionString("BookStoreConnectionString"));
        //    }
        //}
    }
}
