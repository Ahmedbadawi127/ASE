using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipping.Shared;
using Shipping.Shared.Dto;
using Shipping.Shared.Commands.DeliveryMen;
using Shipping.Application.QueryHandler.DeliveryMen;

namespace Shipping.WebUI.Controllers
{
    public class DeliveryMenController : ApiController
    {

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create(CreateDeliveryManCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Update(UpdateDeliveryManCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Delete([FromBody] int Id)
        {
            var res = await Mediator.Send(new DeleteDeliveryManCommand() { Id = Id });
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<DeliveryManDto>>> GetDeliveryMenPage([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetDeliveryMenQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<DeliveryManDto>(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<DeliveryManDto>>> GetDeliveryMen([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetDeliveryMenQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return result;
        }

        [HttpGet("[action]/{Id:int}")]
        public async Task<ActionResult<DeliveryManDto>> GetDeliveryManById(int Id)
        {
            var result = await Mediator.Send(new GetDeliveryManQuery()
            {
                Id = Id
            });

            return result;
        }

    }
}
