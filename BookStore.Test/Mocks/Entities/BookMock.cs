using BookStore.Domain.Entities;
using System;

namespace BookStore.Test.Mocks.Entities
{
    public static class BookMock
    {
        public static Book GetWithNoStock(string key)
        {
            var ret = new Book();
            ret.Id = Guid.Parse(key);
            ret.Title = key;
            ret.StockQty = 0;            

            return ret;
        }

        public static Book GetWithStock(string key)
        {
            var ret = new Book();
            ret.Id = Guid.Parse(key);
            ret.Title = key;
            ret.StockQty = 1;

            return ret;
        }
    }
}
