using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.Title)
            .HasMaxLength(DataSchemaConstants.DefaulsNameLength)
            .IsRequired();

        builder.Property(x => x.Author)
            .HasMaxLength(DataSchemaConstants.DefaulsNameLength)
            .IsRequired();

        builder.HasData(GetSampleData());
    }

    private IEnumerable<Book> GetSampleData()
    {
        var author = "Jeyhun";

        yield return new Book(Guid.NewGuid(), "1", author, 12);
        yield return new Book(Guid.NewGuid(), "2", author, 12);
        yield return new Book(Guid.NewGuid(), "3", author, 12);
        yield return new Book(Guid.NewGuid(), "4", author, 12);
    }
}
