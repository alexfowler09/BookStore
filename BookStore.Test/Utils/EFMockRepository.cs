using Microsoft.EntityFrameworkCore;

namespace BookStore.Test
{
    public class EFMockRepository
    {
        private readonly DbContext _db;

        public EFMockRepository(DbContext db)
        {
            _db = db;
        }

        public void Add<T>(T e)
            where T : class
        {
            _db.Add(e);
            _db.SaveChanges();            
        }
    }
}
