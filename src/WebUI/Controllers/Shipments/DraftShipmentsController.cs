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
    public class DraftShipmentsController : ApiController
    {

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> CreateDraftShipment(CreateDraftShipmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> UpdateDraftShipment(UpdateDraftShipmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> DeleteDraftShipment([FromBody] int Id)
        {
            var res = await Mediator.Send(new DeleteDraftShipmentCommand() { Id = Id });
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<DraftShipmentsDto>>> GetDraftShipmentsPage([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetDraftShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<DraftShipmentsDto>(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<DraftShipmentsDto>>> GetDraftShipments([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetDraftShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return result;
        }

        [HttpGet("[action]/{Id:int}")]
        public async Task<ActionResult<DraftShipmentsDto>> GetDraftShipmentById(int Id)
        {
            var result = await Mediator.Send(new GetDraftShipmentQuery()
            {
                Id = Id
            });

            return result;
        }

    }
}
