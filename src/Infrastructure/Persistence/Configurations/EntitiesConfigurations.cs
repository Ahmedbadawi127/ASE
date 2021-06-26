using Shipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Shipping.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           // builder.HasOne(b => b.DeliveryMan).WithOne(i => i.User)
           //.HasForeignKey<DeliveryMan>(b => b.UserId);

           // builder.HasOne(b => b.Customer).WithOne(i => i.User)
           //            .HasForeignKey<DeliveryMan>(b => b.UserId);
        }
    }



    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(p => p.Shipments).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).IsRequired(true);

        }
    }

    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            // Method intentionally left empty.
        }
    }

    public class DeliveryManConfiguration : IEntityTypeConfiguration<DeliveryMan>
    {
        public void Configure(EntityTypeBuilder<DeliveryMan> builder)
        {
            builder.HasMany(p => p.Shipments).WithOne(c => c.DeliveryMan).HasForeignKey(c => c.DeliveryManId).IsRequired(true);
        }
    }

}