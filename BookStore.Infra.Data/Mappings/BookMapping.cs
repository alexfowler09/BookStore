using BookStore.Domain.Entities;
using BookStore.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Data.Mappings
{
    public class BookMapping : EntityTypeConfiguration<Book>
    {
        public override void Map(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
                .IsRequired()
                .HasColumnType("varchar(150)");                

            builder.Property(b => b.StockQty)
                .IsRequired();

            builder.Property(b => b.AuthorId)
                .IsRequired();

            builder
                .HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId);

            builder
                .ToTable("Book");
        }
    }
}
