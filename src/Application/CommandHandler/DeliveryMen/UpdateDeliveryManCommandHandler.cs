using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Commands.DeliveryMen;

namespace Shipping.Application.CommandHandler.DeliveryMen
{
    public class UpdateDeliveryManCommandHandler : IRequestHandler<UpdateDeliveryManCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public UpdateDeliveryManCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(UpdateDeliveryManCommand request, CancellationToken cancellationToken)
        {

            try
            {

                if (request.Id > 0)
                {

                    var c = await _context.DeliveryMen.FindAsync(request.Id);

                    c.NameAr = request.NameAr;
                    c.NameEn = request.NameEn;
                    c.Address = request.Address;
                    c.Phone = request.Phone;
                    c.StateId = request.StateId;
                    c.StateName = request.StateName;
                    c.CityId = request.CityId;
                    c.CityName = request.CityName;
                    c.Age = request.Age;
                    c.GenderId = request.GenderId;
                    c.GenderName = request.GenderName;
                    c.SId = Guid.NewGuid();
                    c.Active = request.Active;

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
