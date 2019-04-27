using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Notifications;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        protected BaseService(IBaseRepository<TEntity> baseRepository, IDomainNotificationHandler domainNotificationHandler)
        {
            _baseRepository = baseRepository;
            _domainNotificationHandler = domainNotificationHandler;
        }

        public void Add(TEntity obj)
        {
            if (obj.IsValid())
                _baseRepository.Add(obj);
            else
                NotifyDomain(obj.Validations);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public TEntity GetById(Guid id)
        {
            return _baseRepository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _baseRepository.Remove(id);
        }

        public void Update(TEntity obj)
        {            
            if (obj.IsValid())
                _baseRepository.Update(obj);
            else
                NotifyDomain(obj.Validations);
        }

        private void NotifyDomain(List<ValidationError> errors)
        {
            foreach (var error in errors)            
                _domainNotificationHandler.Add(new DomainNotification(error.PropertyName, error.ErrorMessage));            
        }                

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {   
            if (disposing)            
                _baseRepository.Dispose();
        }

        ~BaseService()
        {
            Dispose(false);
        }
    }
}
