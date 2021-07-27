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
using Shipping.Shared.Extensions;
using System.Collections.Generic;

namespace Shipping.Shared.Commands.DeliveryMen
{
    public class CreateDeliveryManFM : CreateDeliveryManCommand
    {


    }

    public class CreateDeliveryManCommand : IRequest<int>
    {

        [DisplayName("رقم الهويه")]
        public Guid SId { get; set; }
        [DisplayName("المعرف")]
        public int Id { get; set; }

        [DisplayName("المدينه")]
        public string CityName { get; set; }

        [DisplayName("المحافظه")]
        public string StateName { get; set; }

        [DisplayName("المحافظه")]
        public int StateId { get; set; }
        [DisplayName("النوع")]
        public int GenderId { get; set; }
        [DisplayName("النوع")]
        public string GenderName { get; set; }
        [DisplayName("السن")]
        public int Age { get; set; }
        [DisplayName("المدينه")]
        public int CityId { get; set; }
        [DisplayName("الإسم بالعربي")]
        public string NameAr { get; set; }
        [DisplayName("الإسم بالانجليزي")]
        public string NameEn { get; set; }
        [DisplayName("التليفون")]
        public string Phone { get; set; }
        [DisplayName("العنوان")]
        public string Address { get; set; }
        [DisplayName("فعال")]
        public bool? Active { get; set; }
        public List<DeliveryManStatesPricesDto> DeliveryManStatesPrices { get; set; } = new List<DeliveryManStatesPricesDto>();

    }

    public class CreateDeliveryManFMValidator : CreateDeliveryManCommandValidator<CreateDeliveryManFM>
    {
        public CreateDeliveryManFMValidator()
        {


        }
    }

    public class CreateDeliveryManCommandValidator : CreateDeliveryManCommandValidator<CreateDeliveryManCommand>
    {
    }
    public class CreateDeliveryManCommandValidator<T> : AbstractValidator<T> where T : CreateDeliveryManCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public CreateDeliveryManCommandValidator()
        {

            RuleFor(v => v.CityId).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateDeliveryManCommand>(i => i.CityId));
            RuleFor(v => v.StateId).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateDeliveryManCommand>(i => i.StateId));
            RuleFor(v => v.NameAr).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateDeliveryManCommand>(i => i.NameAr));
            RuleFor(v => v.NameEn).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateDeliveryManCommand>(i => i.NameEn));
            RuleFor(v => v.Phone).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateDeliveryManCommand>(i => i.Phone));
            RuleFor(v => v.Address).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateDeliveryManCommand>(i => i.Address));
            RuleFor(v => v.GenderId).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateDeliveryManCommand>(i => i.GenderId));
            RuleFor(v => v.Age).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateDeliveryManCommand>(i => i.Age));

        }
    }


}

