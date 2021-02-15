using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shipping.Application;
using Shipping.Application.Common.Interfaces;
using Shipping.Application.Common.Models;
using Shipping.Shared;
using Shipping.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Shipping.Application.Lookups
{


    public interface ILookupService
    {
        Task<List<LookupDto>> GetLookups(string Key, string Id = null, int UserTypeId = 0, string LoggedInUser = null, string Search = null, int Take = 0, int Skip = 0, CancellationToken cancellationToken = new CancellationToken());
        Task<List<LookupWithCategDto>> GetLookupsWithCateg(string Key, string Id = null, int UserTypeId = 0, int CategoryId = 0, string LoggedInUser = null, string Search = null, int Take = 0, int Skip = 0, CancellationToken cancellationToken = new CancellationToken());

    }

    public partial class LookupService : ILookupService
    {

        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public LookupService(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _cache = cache;
        }

        public async Task<List<LookupDto>> GetLookups(string Key, string Id = null, int UserTypeId = 0, string LoggedInUser = null, string Search = null, int Take = 0, int Skip = 0, CancellationToken cancellationToken = new CancellationToken())
        {

            if (Key.Equals("AllStates", StringComparison.OrdinalIgnoreCase))
            {

                var items = new List<LookupDto>()
                {
                    new LookupDto() { Id = 1, DisplayName = "القاهره"},
                    new LookupDto() { Id = 2, DisplayName = "الجيزه"},
                    new LookupDto() { Id = 3, DisplayName = "المنيا"},
                    new LookupDto() { Id = 4, DisplayName = "الاسكندريه"},
                    new LookupDto() { Id = 5, DisplayName = "بني سويف"},
                };

                if (!string.IsNullOrEmpty(Search))
                {
                    return items.Where(i => i.DisplayName.ToLower().Contains(Search.ToLower())).ToList();
                }
                if (Take > 0)
                {
                    return items.OrderBy(i => i.DisplayName).Take(Take).ToList();
                }

                return items.ToList();
            }

            else if (Key.Equals("Genders", StringComparison.OrdinalIgnoreCase))
            {

                var items = new List<LookupDto>()
                {
                    new LookupDto() { Id = 1, DisplayName = "ذكر"},
                    new LookupDto() { Id = 2, DisplayName = "انثى"}
                };

                return items.ToList();
            }



            return null;
        }
        public async Task<List<LookupWithCategDto>> GetLookupsWithCateg(string Key, string Id = null, int UserTypeId = 0, int CategoryId = 0, string LoggedInUser = null, string Search = null, int Take = 0, int Skip = 0, CancellationToken cancellationToken = new CancellationToken())
        {

            if (Key.Equals("AllCities", StringComparison.OrdinalIgnoreCase))
            {

                var items = new List<LookupWithCategDto>(CategoryId)
                {
                    new LookupWithCategDto() { Id = 1, DisplayName="الهرم", CategoryId=2},
                    new LookupWithCategDto() { Id = 2, DisplayName = "فيصل",CategoryId=2},
                    new LookupWithCategDto() { Id = 3, DisplayName = "مصر الجديده",CategoryId=1},
                    new LookupWithCategDto() { Id = 4, DisplayName = "سان باولو", CategoryId=4},
                    new LookupWithCategDto() { Id = 5, DisplayName = "سملوط",CategoryId=5},
                };

                if (CategoryId > 0)
                {
                    return items.Where(e => e.CategoryId == CategoryId).ToList();
                }

                if (!string.IsNullOrEmpty(Search))
                {
                    return items.Where(i => i.DisplayName.ToLower().Contains(Search.ToLower())).ToList();
                }

                if (Take > 0)
                {
                    return items.OrderBy(i => i.DisplayName).Take(Take).ToList();
                }


                return items.ToList();
            }

            return null;
        }

    }
}
