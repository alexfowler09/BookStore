using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        public static void DetachAllEntities(DbContext db)
        {
            var changedEntriesCopy = db.ChangeTracker.Entries()                
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

    }
}
