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
    public class ShipmentsController : ApiController
    {

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create(CreateShipmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Update(UpdateShipmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Delete([FromBody] int Id)
        {
            var res = await Mediator.Send(new DeleteShipmentCommand() { Id = Id });
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<ShipmentsDto>>> GetShipmentsPage([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<ShipmentsDto>(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<ShipmentsDto>>> GetShipments([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return result;
        }

        [HttpGet("[action]/{Id:int}")]
        public async Task<ActionResult<ShipmentsDto>> GetShipmentById(int Id)
        {
            var result = await Mediator.Send(new GetShipmentQuery()
            {
                Id = Id
            });

            return result;
        }

    }
}
