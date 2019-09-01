using BookStore.Domain.Entities;
using BookStore.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Data.Mappings
{
    public class AuthorMapping : EntityTypeConfiguration<Author>
    {
        public override void Map(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .ToTable("Author");
        }
    }
}
