using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetBydId(Guid id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
