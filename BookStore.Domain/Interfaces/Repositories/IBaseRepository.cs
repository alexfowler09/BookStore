using BookStore.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
