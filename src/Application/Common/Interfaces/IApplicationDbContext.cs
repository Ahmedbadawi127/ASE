using Shipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Shipping.Application.Common.Interfaces
{
    public partial interface IApplicationDbContext
    {
        //DbSet<User> User { get; set; }
        DbSet<Customer> Customers { get; set; }


    }
}
