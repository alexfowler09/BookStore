using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.Test
{
    public static class Utils
    {
        public static TDataContext GetDbContext<TDataContext>()
            where TDataContext : DbContext
        {
            var builder = new DbContextOptionsBuilder<TDataContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());            
            var options = builder.Options;            

            var db = (TDataContext)Activator.CreateInstance(typeof(TDataContext), options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }
    }
}
