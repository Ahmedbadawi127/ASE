using Shipping.Domain.Entities;
using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Commands.Customers;

namespace Shipping.Application.CommandHandler.Customers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public CreateCustomerCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            try
            {

                var entity = new Customer
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

                await _context.Customers.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
