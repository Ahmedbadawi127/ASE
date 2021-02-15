using Shipping.Shared.Dto;
using System;
using MediatR;
using AutoMapper;
using System.Net.Http;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace Shipping.Shared.Commands
{
    public class CreateShipmentsFM : CreateShipmentsCommand
    {


        public int? CustomerIdFM { get { return (CustomerId > 0) ? CustomerId : new Nullable<int>(); } set { CustomerId = (value ?? 0); } }
        public int? ReceiverStateIdFM { get { return (ReceiverStateId > 0) ? ReceiverStateId : new Nullable<int>(); } set { ReceiverStateId = (value ?? 0); } }
        public int? ReceiverCityIdFM { get { return (ReceiverCityId > 0) ? ReceiverCityId : new Nullable<int>(); } set { ReceiverCityId = (value ?? 0); } }

    }

    public class CreateShipmentsCommand : IRequest<int>
    {
        public int? ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public int ReceiverStateId { get; set; }
        public string ReceiverStateName { get; set; }
        public int ReceiverCityId { get; set; }
        public string ReceiverCityName { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public int CashToBeCollected { get; set; }


    }

    public class CreateShipmentsFMValidator : CreateShipmentsCommandValidator<CreateShipmentsFM>
    {
        public CreateShipmentsFMValidator()
        {


        }
    }

    public class CreateShipmentsCommandValidator : CreateShipmentsCommandValidator<CreateShipmentsCommand>
    {
    }
    public class CreateShipmentsCommandValidator<T> : AbstractValidator<T> where T : CreateShipmentsCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public CreateShipmentsCommandValidator()
        {



        }
    }


}

