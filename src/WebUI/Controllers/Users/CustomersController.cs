using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipping.Shared.Dto;
using Shipping.Shared;
using Shipping.Shared.Commands.Customers;
using Shipping.Application.QueryHandler.Customers;

namespace Shipping.WebUI.Controllers
{
    public class CustomersController : ApiController
    {


        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Update(UpdateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Delete([FromBody] int Id)
        {
            var res = await Mediator.Send(new DeleteCustomerCommand() { Id = Id });
            return Ok(res);
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<CustomersDto>>> GetCustomersPage([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetCustomersQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<CustomersDto>(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<CustomersDto>>> GetCustomers([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetCustomersQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return result;
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
