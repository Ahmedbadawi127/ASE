using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipping.Shared;
using Shipping.Shared.Dto;
using Shipping.Shared.Commands.Geography.States;
using Shipping.Application.QueryHandler.Geography.States;

namespace Shipping.WebUI.Controllers
{
    public class StatesController : ApiController
    {


        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create(CreateStateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Update(UpdateStateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Delete([FromBody] int Id)
        {
            var res = await Mediator.Send(new DeleteStateCommand() { Id = Id });
            return Ok(res);
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<LookupDto>>> GetStatesPage([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetStatesQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<LookupDto>(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<LookupDto>>> GetStates([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetStatesQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return result;
        }


        [HttpGet("[action]/{Id:int}")]
        public async Task<ActionResult<LookupDto>> GetStateById(int Id)
        {
            var result = await Mediator.Send(new GetStateQuery()
            {
                Id = Id
            });

            return result;
        }


    }
}
