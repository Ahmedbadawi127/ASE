using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Commands.Shipments;

namespace Shipping.Application.CommandHandler.Shipments
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public DeleteShipmentCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {

            try
            {

                if (request.Id > 0)
                {

                    var c = await _context.Shipments.FindAsync(request.Id);
                    if (c != null)
                    {
                        _context.Shipments.Remove(c);
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
