using Shipping.Domain.Entities;
using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Commands.DeliveryMen;

namespace Shipping.Application.CommandHandler.DeliveryMen
{
    public class CreateDeliveryManCommandHandler : IRequestHandler<CreateDeliveryManCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public CreateDeliveryManCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(CreateDeliveryManCommand request, CancellationToken cancellationToken)
        {

            try
            {

                var DeliveryMan = new DeliveryMan
                {
                    NameAr = request.NameAr,
                    NameEn = request.NameEn,
                    Address = request.Address,
                    Phone = request.Phone,
                    StateId = request.StateId,
                    StateName = request.StateName,
                    CityId = request.CityId,
                    CityName = request.CityName,
                    Age = request.Age,
                    GenderId = request.GenderId,
                    GenderName = request.GenderName,
                    SId = Guid.NewGuid(),
                    Active = request.Active,
                };

                await _context.DeliveryMen.AddAsync(DeliveryMan);
                await _context.SaveChangesAsync(cancellationToken);


                foreach (var state in request.States)
                {
                    var DeliveryManState = new DeliveryManState
                    {
                        DeliveryManId = DeliveryMan.Id,
                        StateId = state
                    };

                    await _context.DeliveryMenStates.AddAsync(DeliveryManState);
                }


                return DeliveryMan.Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
