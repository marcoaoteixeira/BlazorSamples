using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nameless.Bookshelf.Domain.Entities;

namespace Nameless.Bookshelf.Infrastructure.Books.Persistence {
    public sealed class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book> {
        public void Configure(EntityTypeBuilder<Book> builder) {
            builder.HasKey(entity => entity.ID);

            builder.Property(entity => entity.ID)
                   .ValueGeneratedNever();

            builder.Property(entity => entity.Title)
                   .IsRequired();

            builder.Property(entity => entity.Overview);

            builder.Property(entity => entity.PublishDate);

            builder.Property(entity => entity.Rating);
        }
    }
}
