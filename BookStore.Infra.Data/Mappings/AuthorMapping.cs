using BookStore.Domain.Entities;
using BookStore.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Data.Mappings
{
    public class AuthorMapping : EntityTypeConfiguration<Author>
    {
        public override void Map(EntityTypeBuilder<Author> author)
        {
            author.Property(a => a.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            author
                .ToTable("Author");
        }
    }
}
