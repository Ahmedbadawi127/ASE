using AutoMapper;
using Shipping.Application;
using Shipping.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared;
using System.Linq;
using Shipping.Shared.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace Shipping.Application.Lookups
{
    public class GetDeliveryManQuery : IRequest<DeliveryManDto>
    {
        public int Id { get; set; }
    }
    public class GetDeliveryManQueryHandler : IRequestHandler<GetDeliveryManQuery, DeliveryManDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetDeliveryManQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<DeliveryManDto> Handle(GetDeliveryManQuery request, CancellationToken cancellationToken)
        {
            var e = _context.DeliveryMan.First(e => e.Id == request.Id);
            var item = new DeliveryManDto()
            {
                Id = e.Id,
                SId = e.SId,
                NameAr = e.NameAr,
                NameEn = e.NameEn,
                Active = e.Active,
                Age = e.Age,
                CityName = e.CityName,
                GenderName = e.GenderName,
                Phone = e.Phone,
                StateName = e.StateName,
                Address = e.Address
            };


            return item;
        }
    }

}
