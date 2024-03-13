using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.DAL.Configurations
{
    public class TextsOfBooksConfiguration : IEntityTypeConfiguration<TextOfBook>
    {
        public void Configure(EntityTypeBuilder<TextOfBook> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Text).IsRequired();

            builder.HasOne(t => t.Book)
                .WithOne(b => b.TextOfBook)
                .HasForeignKey<TextOfBook>(t => t.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
