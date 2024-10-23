using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraGreateDivanShop.Domain;

namespace UltraGreateDivanShop.Database.EntityTypeConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

        builder.HasIndex(product => product.Id)
            .IsUnique();

        builder.Property(product => product.Title)
            .HasMaxLength(100)
            .IsRequired();
    }
}
