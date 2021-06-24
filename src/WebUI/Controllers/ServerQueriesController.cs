﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shipping.Application.Lookups;
using Shipping.Shared;
using Shipping.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping.WebUI.Controllers
{
    public class ServerQueriesController : ApiController
    {

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<CustomersDto>>> GetCustomers([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetCustomersQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<CustomersDto>(result);
        }

                [HttpGet("[action]/{Id:int}")]
        public async Task<ActionResult<CustomersDto>> GetCustomerById(int Id)
        {
            var result = await Mediator.Send(new GetCustomerQuery()
            {
                Id = Id
            });

            return result;
        }



    }
}
