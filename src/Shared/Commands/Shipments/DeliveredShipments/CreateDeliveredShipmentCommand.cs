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
    public class CreateDeliveredShipmentFM : CreateDeliveredShipmentCommand
    {

    }

    public class CreateDeliveredShipmentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public ShipmentStatus Status { get; set; }
    }

    public class CreateDeliveredShipmentFMValidator : CreateDeliveredShipmentCommandValidator<CreateDeliveredShipmentFM>
    {
        public CreateDeliveredShipmentFMValidator()
        {


        }
    }

    public class CreateDeliveredShipmentCommandValidator : CreateDeliveredShipmentCommandValidator<CreateDeliveredShipmentCommand>
    {
    }
    public class CreateDeliveredShipmentCommandValidator<T> : AbstractValidator<T> where T : CreateDeliveredShipmentCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public CreateDeliveredShipmentCommandValidator()
        {



        }
    }


}

