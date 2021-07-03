using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Commands.DeliveryMen;

namespace Shipping.Application.CommandHandler.DeliveryMen
{
    public class DeleteDeliveryManCommandHandler : IRequestHandler<DeleteDeliveryManCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public DeleteDeliveryManCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(DeleteDeliveryManCommand request, CancellationToken cancellationToken)
        {

            try
            {

                if (request.Id > 0)
                {

                    var c = await _context.DeliveryMan.FindAsync(request.Id);
                    if (c != null)
                    {
                        _context.DeliveryMan.Remove(c);
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
