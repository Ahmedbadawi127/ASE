using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipping.Shared;
using Shipping.Shared.Dto;
using Shipping.Shared.Commands.Shipments;
using Shipping.Application.QueryHandler.Shipments;

namespace Shipping.WebUI.Controllers
{
    public class DeliveredShipmentsController : ApiController
    {

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> CreateDeliveredShipment(CreateDeliveredShipmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<DeliveredShipmentsDto>>> GetDeliveredShipmentsPage([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetDeliveredShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<DeliveredShipmentsDto>(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<DeliveredShipmentsDto>>> GetDeliveredShipments([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetDeliveredShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return result;
        }

    }
}
