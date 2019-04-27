using System;
using System.Collections.Generic;

namespace BookStore.Application.Interfaces
{
    public interface IBaseAppService<TViewModel, TEntity> : IDisposable
    {
        Guid? Add(TViewModel obj);
        TViewModel GetById(Guid id);
        IEnumerable<TViewModel> GetAll();
        bool Remove(Guid id);
        bool Update(TViewModel viewModel);
    }
}
