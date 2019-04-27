using BookStore.Application.ViewModels.Interfaces;
using System;

namespace BookStore.Application.ViewModels
{
    public class BookViewModel : IBaseViewModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public int StockQty { get; set; }
        public Guid AuthorId { get; set; }

        public AuthorViewModel Author { get; set; } = new AuthorViewModel();       
    }
}
