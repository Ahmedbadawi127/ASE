using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Commands.Customers;

namespace Shipping.Application.CommandHandler.Customers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public DeleteCustomerCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            try
            {

                if (request.Id > 0)
                {

                    var c = await _context.Customers.FindAsync(request.Id);
                    if (c != null)
                    {
                        _context.Customers.Remove(c);
                        await _context.SaveChangesAsync(cancellationToken);
                        return c.Id;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }
    }
}
