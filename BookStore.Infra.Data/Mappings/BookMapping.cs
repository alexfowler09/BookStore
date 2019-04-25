using BookStore.Domain.Entities;
using BookStore.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Data.Mappings
{
    public class BookMapping : EntityTypeConfiguration<Book>
    {
        public override void Map(EntityTypeBuilder<Book> book)
        {
            book.Property(b => b.Title)
                .IsRequired()
                .HasColumnType("varchar(150)");                

            book.Property(b => b.StockQty)
                .IsRequired();

            book.Property(b => b.AuthorId)
                .IsRequired();

            book
                .HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId);

            book
                .ToTable("Book");
        }
    }
}
