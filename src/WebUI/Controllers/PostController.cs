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
            //command.userName = User.Identity.Name;
            return await Mediator.Send(command);
        }



    }
}
