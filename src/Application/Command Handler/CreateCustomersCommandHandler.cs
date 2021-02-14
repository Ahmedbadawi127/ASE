using Shipping.Domain.Entities;
using Shipping.Application.Common.Exceptions;
using Shipping.Application.Common.Interfaces;
using Shipping.Shared;
using Shipping.Shared.Commands;
using Shipping.Shared.Dto;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;

namespace Shipping.Application.CreateFlowCommands
{
    public class CreateCustomersCommandHandler : IRequestHandler<CreateCustomersCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public CreateCustomersCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(CreateCustomersCommand request, CancellationToken cancellationToken)
        {

            var userEntity = new User
            {
                SId = Guid.NewGuid(),
                NameAr = request.NameAr,
                NameEn = request.NameEn,
                UserTypeId = 1
            };


            var entity = new Customer
            {
                //UserTypeId = 1,
                // customer = 1, staff = 2
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
            };

            try
            {

                await _context.Customers.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception e)
            {

                throw e;
            }
            return entity.Id;

        }
    }
}
