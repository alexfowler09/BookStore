using System;
using System.Linq;

namespace BookStore.Domain.Entities
{
    public class Book : Entity<Book>
    {   
        public string Title { get; set; }
        public int StockQty { get; set; }
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }

        internal override bool IsValid()
        {
            Validate();
            return !Validations.Any();
        }

        private void Validate()
        {
            if (this.Title == null)
                Validations.Add(new ValidationError("Title","Título não pode ser nulo"));

            if (this.Title == string.Empty)
                Validations.Add(new ValidationError("Title", "Título não pode ser vazio"));
            
            if (this.StockQty <= -1)
                Validations.Add(new ValidationError("StockQty", "Estoque tem que ser maior ou igual a 0"));
        }
    }    
}
