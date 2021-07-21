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
using System.Collections.Generic;

namespace Shipping.Shared.Commands.Shipments
{
    // Master
    public class CreateApprovedShipmentFM : CreateApprovedShipmentCommand
    {

    }

    public class CreateApprovedShipmentCommand : IRequest<int>
    {
        public ApprovedShipmentsCommand ApprovedShipments { get; set; }
        public int Id { get; set; }
        public ShipmentStatus Status { get; set; }
        public string Notes { get; set; }
    }

    public class CreateApprovedShipmentFMValidator : CreateApprovedShipmentCommandValidator<CreateApprovedShipmentFM>
    {
        public CreateApprovedShipmentFMValidator()
        {


        }
    }

    public class CreateApprovedShipmentCommandValidator : CreateApprovedShipmentCommandValidator<CreateApprovedShipmentCommand>
    {
    }
    public class CreateApprovedShipmentCommandValidator<T> : AbstractValidator<T> where T : CreateApprovedShipmentCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public CreateApprovedShipmentCommandValidator()
        {



        }
    }

    // Lines
    public class ApprovedShipmentsFM : ApprovedShipmentsCommand
    {

    }

    public class ApprovedShipmentsCommand : IRequest<int>
    {
        public CreateApprovedShipmentCommand CreateApprovedShipment { get; set; }
        public int ApprovedShipmentId { get; set; }
        public int DeliveryManId { get; set; }
        public string DeliveryManName { get; set; }
        public List<ShipmentsPerDeliveryManFM> ShipmentsPerDeliveryMan { get; set; }
    }

    public class ApprovedShipmentsFMValidator : ApprovedShipmentsCommandValidator<ApprovedShipmentsFM>
    {
        public ApprovedShipmentsFMValidator()
        {


        }
    }

    public class ApprovedShipmentsCommandValidator : ApprovedShipmentsCommandValidator<ApprovedShipmentsCommand>
    {
    }
    public class ApprovedShipmentsCommandValidator<T> : AbstractValidator<T> where T : ApprovedShipmentsCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public ApprovedShipmentsCommandValidator()
        {



        }
    }

    public class ShipmentsPerDeliveryManFM
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
        public int DeliveryManId { get; set; }
        public string DeliveryManName { get; set; }

        public ApprovedShipmentsFM ApprovedShipments { get; set; }
    }

}

