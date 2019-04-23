using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add(TEntity obj)
        {
            return _baseRepository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public TEntity GetBydId(Guid id)
        {
            return _baseRepository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _baseRepository.Remove(obj);
        }

        public TEntity Update(TEntity obj)
        {
            return _baseRepository.Update(obj);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
