using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Application.Lookups;
using Shipping.Shared;
using Shipping.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.WebUI.Controllers
{
    public class LookupsController : ApiController
    {
 
        [HttpGet("[action]/{DataKey}")]
        public async Task<List<LookupDto>> GetLookups(string DataKey, [FromQuery] int UserTypeId, [FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetLookupQuery()
            {
                LoggedInUser = User.Identity.Name,
                DataKey = DataKey,
                UserTypeId = UserTypeId,
                Search = Search,
                Take = Take,
                Skip = Skip,
            });
            return result;

        }
        

    }
}
