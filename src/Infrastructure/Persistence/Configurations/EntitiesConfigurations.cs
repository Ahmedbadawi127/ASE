using Shipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Shipping.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            //builder.HasMany<Customer>(p => p.Customers).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(true);

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

        }
    }

}