using BookStore.Domain.Entities;
using System;

namespace BookStore.Test.Mocks.Entities
{
    public static class AuthorMock
    {
        public static Author Get(string key)
        {
            var ret = new Author();
            ret.Id = Guid.Parse(key);
            ret.Name = key;

            return ret;
        }
    }
}
