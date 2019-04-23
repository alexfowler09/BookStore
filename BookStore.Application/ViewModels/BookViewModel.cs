using System;

namespace BookStore.Application.ViewModels
{
    public class BookViewModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public int StockQty { get; set; }
        public Guid AuthorId { get; set; }

        public AuthorViewModel Author { get; set; } = new AuthorViewModel();       
    }
}
