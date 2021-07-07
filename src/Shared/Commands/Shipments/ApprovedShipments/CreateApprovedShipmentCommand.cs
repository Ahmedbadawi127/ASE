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
    public class CreateApprovedShipmentFM : CreateApprovedShipmentCommand
    {

    }

    public class CreateApprovedShipmentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public ShipmentStatus Status { get; set; }
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


}

