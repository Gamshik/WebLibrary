using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.DAL.Configurations
{
    public class BooksPreviewsConfiguration : IEntityTypeConfiguration<BookPreview>
    {
        public void Configure(EntityTypeBuilder<BookPreview> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.HasIndex(b => b.Title)
                .IsUnique()
                .HasFilter("[Title] IS NOT NULL");
            builder.Property(b => b.Cover);
            builder.Property(b => b.Author).IsRequired();
            builder.Property(b => b.Description);

            builder.HasOne(b => b.TextOfBook)
                .WithOne(t => t.Book)
                .HasForeignKey<TextOfBook>(t => t.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
