using BookStore.Application.Interfaces;
using BookStore.Application.Notifications;
using BookStore.Application.ViewModels.Interfaces;
using BookStore.Domain;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Notifications;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public abstract class BaseAppService<TViewModel, TEntity> : IBaseAppService<TViewModel, TEntity>
        where TViewModel : IBaseViewModel 
        where TEntity : Entity<TEntity>
    {
        private readonly IBaseService<TEntity> _baseService;
        private readonly IDomainNotificationHandler _domainNotificationHandler;
        private readonly IServiceNotificationHandler _serviceNotificationHandler;        

        protected BaseAppService(IBaseService<TEntity> baseService, 
            IDomainNotificationHandler domainNotificationHandler,
            IServiceNotificationHandler serviceNotificationHandler)
        {
            _baseService = baseService;
            _domainNotificationHandler = domainNotificationHandler;
            _serviceNotificationHandler = serviceNotificationHandler;            
        }

        public Guid? Add(TViewModel obj)
        {
            var newObj = MapViewModelToEntity(obj);

            BusinessValidation(newObj);

            if (!IsBusinessValid())
                return null;

            _baseService.Add(newObj);

            if (_domainNotificationHandler.HasNotifications())
            {
                AddDomainValidations(_domainNotificationHandler.GetNotifications());
                return null;
            }
            
            return newObj.Id;
        }

        public TViewModel GetById(Guid id)
        {
            var obj = _baseService.GetById(id);
            return MapEntityToViewModel(obj);
        }

        public IEnumerable<TViewModel> GetAll()
        {
            var ret = new List<TViewModel>();

            var entities = _baseService.GetAll();
            foreach (var entity in entities)
                ret.Add(MapEntityToViewModel(entity));


            return ret;
        }

        public bool Remove(Guid id)
        {
            if (_baseService.GetById(id) == null)
                return false;

            _baseService.Remove(id);
            return true;
        } 

        public bool Update(TViewModel viewModel)
        {
            return UpdateRecord(viewModel);
        }

        protected void NotifyRecordNotFound(string type, string message)
        {
            _serviceNotificationHandler.Add(new ServiceNotification(type, message));
        }

        protected bool ProcessUpdate(TEntity entity)
        {
            BusinessValidation(entity);

            if (!IsBusinessValid())
                return false;

            _baseService.Update(entity);
        
            if (_domainNotificationHandler.HasNotifications())
            {
                AddDomainValidations(_domainNotificationHandler.GetNotifications());
                return false;
            }

            return true;
        }

        private void AddDomainValidations(IEnumerable<DomainNotification> notifications)
        {
            foreach (var notification in notifications)
                _serviceNotificationHandler.Add(new ServiceNotification(notification.Key, notification.Value));
        }

        private bool IsBusinessValid()
        {
            return !_serviceNotificationHandler.HasNotifications();
        }

        protected abstract bool UpdateRecord(TViewModel viewModel);

        protected abstract void BusinessValidation(TEntity entity);

        protected abstract TViewModel MapEntityToViewModel(TEntity entity);

        protected abstract TEntity MapViewModelToEntity(TViewModel viewModel);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _baseService.Dispose();
        }  

        ~BaseAppService()
        {
            Dispose(false);
        }
    }
}
