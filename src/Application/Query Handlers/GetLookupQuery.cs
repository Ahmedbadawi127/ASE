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
    public class GetLookupQuery : IRequest<List<LookupDto>>
    {
        public string LoggedInUser { get; set; }
        public string DataKey { get; set; }
        public string Id { get; set; }
        public int UserTypeId { get; set; }
        public string Search { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
    public class GetEmployeeDataQueryHandler : IRequestHandler<GetLookupQuery, List<LookupDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILookupService _lookupService;
        private readonly IMemoryCache _cache;

        public GetEmployeeDataQueryHandler(IMemoryCache cache, IMapper mapper, ILookupService lookupService)
        {
            _lookupService = lookupService;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<List<LookupDto>> Handle(GetLookupQuery request, CancellationToken cancellationToken)
        {
            return await _lookupService.GetLookups
                (
                Key: request.DataKey
                ,Id: request.Id
                ,Search: request.Search
                ,UserTypeId: request.UserTypeId
                ,LoggedInUser: request.LoggedInUser
                , Take:request.Take
                ,Skip:request.Skip
                , cancellationToken: cancellationToken);
        }
    }

}
