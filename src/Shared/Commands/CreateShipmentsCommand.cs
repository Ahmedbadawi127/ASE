﻿using Shipping.Shared.Dto;
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

namespace Shipping.Shared.Commands
{
    public class CreateShipmentsFM : CreateShipmentsCommand
    {

    }

    public class CreateShipmentsCommand : IRequest<int>
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

