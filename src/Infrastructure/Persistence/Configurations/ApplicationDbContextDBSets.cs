using Shipping.Application.Common.Interfaces;
using Shipping.Domain.Common;
using Shipping.Domain.Entities;
using Shipping.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Shipping.Infrastructure.Persistence
{
    public partial class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {

        //public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<DeliveryMan> DeliveryMan { get; set; }


    }
}
