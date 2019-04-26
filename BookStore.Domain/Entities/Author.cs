using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Entities
{
    public class Author : Entity<Author>
    {   
        public string Name { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }

        public override bool IsValid()
        {
            Validate();
            return !Validations.Any();
        }

        private void Validate()
        {
            if (this.Name == null)
                Validations.Add(new ValidationError("Name", "Nome não pode ser nulo"));

            if (this.Name == string.Empty)
                Validations.Add(new ValidationError("Name", "Nome não pode ser vazio"));
        }
    }
}
