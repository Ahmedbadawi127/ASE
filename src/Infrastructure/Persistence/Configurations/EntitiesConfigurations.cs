using Shipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Shipping.Infrastructure.Persistence.Configurations
{
    //public class UserConfiguration : IEntityTypeConfiguration<User>
    //{
    //    public void Configure(EntityTypeBuilder<User> builder)
    //    {
    //       // builder.HasOne(b => b.DeliveryMan).WithOne(i => i.User)
    //       //.HasForeignKey<DeliveryMan>(b => b.UserId);

    //       // builder.HasOne(b => b.Customer).WithOne(i => i.User)
    //       //            .HasForeignKey<DeliveryMan>(b => b.UserId);
    //    }
    //}



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
            builder.HasOne(p => p.DeliveryMan).WithMany(c => c.Shipments);
            builder.HasOne(p => p.Customer).WithMany(c => c.Shipments);

            // one-to-one relations with shipments status tables
            builder.HasOne(a => a.ApprovedShipment).WithOne(b => b.Shipment).HasForeignKey<ApprovedShipment>(b => b.ShipmentRef);

        }
    }

    public class DeliveryManConfiguration : IEntityTypeConfiguration<DeliveryMan>
    {
        public void Configure(EntityTypeBuilder<DeliveryMan> builder)
        {
            builder.HasMany(p => p.Shipments).WithOne(c => c.DeliveryMan);
        }
    }

    public class ApprovedShipmentConfiguration : IEntityTypeConfiguration<ApprovedShipment>
    {
        public void Configure(EntityTypeBuilder<ApprovedShipment> builder)
        {

        }
    }

    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {

        }
    }

    public class DeliveryManStateConfiguration : IEntityTypeConfiguration<DeliveryManStatesPrices>
    {
        public void Configure(EntityTypeBuilder<DeliveryManStatesPrices> builder)
        {
            builder.HasKey(bc => new { bc.DeliveryManId, bc.StateId });
            builder.HasOne(bc => bc.DeliveryMan).WithMany(b => b.DeliveryMenStates).HasForeignKey(bc => bc.DeliveryManId);
            builder.HasOne(bc => bc.State).WithMany(b => b.DeliveryMenStatesPrices).HasForeignKey(bc => bc.StateId);
        }
    }
}