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
    public class ApprovedShipmentsController : ApiController
    {

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> CreateApprovedShipment(CreateApprovedShipmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<ApprovedShipmentsDto>>> GetApprovedShipmentsPage([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetApprovedShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<ApprovedShipmentsDto>(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<ApprovedShipmentsDto>>> GetApprovedShipments([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetApprovedShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return result;
        }

    }
}
