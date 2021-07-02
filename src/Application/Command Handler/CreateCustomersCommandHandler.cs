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
using Shipping.Domain.Enums;

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

            try
            {
                if (request.Id > 0)
                {
                    var c = _context.Customers.First(e => e.Id == request.Id);

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
                else
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

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
    }
}
