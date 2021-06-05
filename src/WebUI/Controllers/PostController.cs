using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shipping.Shared.Commands;
using Shipping.Application;
using MediatR;

namespace Shipping.WebUI.Controllers
{
    public class PostController : ApiController
    {


        [HttpPost("[action]")]
        public async Task<ActionResult<int>> CreateCustomer(CreateCustomersCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> CreateShipments(CreateShipmentsCommand command)
        {
            return await Mediator.Send(command);
        }

    }
}
