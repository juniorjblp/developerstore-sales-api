using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(u => u.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(u => u.Category)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Quantity)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(u => u.UpdatedAt)
                .HasColumnType("timestamp with time zone");
        }
    }
}
