using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.ProductId)
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Discount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.SaleId)
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(x => x.Sale)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
