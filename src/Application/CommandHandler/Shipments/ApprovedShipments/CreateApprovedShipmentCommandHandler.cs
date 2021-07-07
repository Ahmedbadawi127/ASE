using Shipping.Domain.Entities;
using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Domain.Enums;
using Shipping.Shared.Commands.Shipments;

namespace Shipping.Application.CommandHandler.Shipments
{
    public class CreateApprovedShipmentCommandHandler : IRequestHandler<CreateApprovedShipmentCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public CreateApprovedShipmentCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(CreateApprovedShipmentCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (request.Id > 0)
                {
                    var c = await _context.Shipments.FindAsync(request.Id);

                    c.Status = ShipmentStatus.Approved;

                    await _context.SaveChangesAsync(cancellationToken);
                    return c.Id;
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
