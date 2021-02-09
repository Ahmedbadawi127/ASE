using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Shared.Commands;

namespace WebUI.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IApplicationDbContext _context;

        public AccountController(IApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize]
        [HttpPost("[action]")]
        public async Task<UserBasicInfo> CreateCustomer()
        {
            var luser = await _context.User.SingleAsync(u => u.SId == User.Identity.Name);
            return new UserBasicInfo 
            { 
                //Id = luser.Id
                //,Name = luser.NameAr
            };
        }

    }
}
