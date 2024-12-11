using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estore.Model.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.Property(p => p.MadeInIndia).IsRequired();
            builder.Property(p => p.PriceSegment).IsRequired();
            builder.Property(p => p.ProductTypeId).IsRequired();
            builder.Property(p => p.ProductBrandId).IsRequired();

        }
    }
}
