using AutoMapper;
using Shipping.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Shipping.Shared.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace Shipping.Application.QueryHandler.Customers
{
    public class GetCustomerQuery : IRequest<CustomersDto>
    {
        public int Id { get; set; }
    }
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomersDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetCustomerQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<CustomersDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var e = _context.Customers.First(e => e.Id == request.Id);
            var item = new CustomersDto()
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
