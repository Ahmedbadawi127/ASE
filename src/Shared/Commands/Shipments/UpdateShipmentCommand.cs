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
using Shipping.Domain.Enums;

namespace Shipping.Shared.Commands.Shipments
{
    public class UpdateShipmentFM : UpdateShipmentCommand
    {

    }

    public class UpdateShipmentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ShipmentName { get; set; }
        public int CustomerId { get; set; }
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
        public ShipmentStatus Status { get; set; }


    }

    public class UpdateShipmentFMValidator : UpdateShipmentCommandValidator<UpdateShipmentFM>
    {
        public UpdateShipmentFMValidator()
        {


        }
    }

    public class UpdateShipmentCommandValidator : UpdateShipmentCommandValidator<UpdateShipmentCommand>
    {
    }
    public class UpdateShipmentCommandValidator<T> : AbstractValidator<T> where T : UpdateShipmentCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public UpdateShipmentCommandValidator()
        {



        }
    }


}

