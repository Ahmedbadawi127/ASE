using Microsoft.AspNetCore.Authorization;
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

        // customers

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

        [HttpGet("[action]/{Id:int}")]
        public async Task<ActionResult<CustomersDto>> GetCustomerById(int Id)
        {
            var result = await Mediator.Send(new GetCustomerQuery()
            {
                Id = Id
            });

            return result;
        }

        // DeliveryMan

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<DeliveryManDto>>> GetDeliveryMan([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetDeliveryMenQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<DeliveryManDto>(result);
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

        // Shipment

        [HttpGet("[action]")]
        public async Task<ActionResult<PagedDataResult<ShipmentsDto>>> GetShipments([FromQuery] string Search, [FromQuery] int Take, [FromQuery] int Skip)
        {
            var result = await Mediator.Send(new GetShipmentsQuery()
            {
                Search = Search,
                Take = Take,
                Skip = Skip,
            });

            return new PagedDataResult<ShipmentsDto>(result);
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
