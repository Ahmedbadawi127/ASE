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
    public class CreateCustomersFM : CreateCustomersCommand
    {


        public int? StateIdFM { get { return (StateId > 0) ? StateId : new Nullable<int>(); } set { StateId = (value ?? 0); } }
        public int? CityIdFM { get { return (CityId > 0) ? CityId : new Nullable<int>(); } set { CityId = (value ?? 0); } }
        public int? GenderIdFM { get { return (GenderId > 0) ? GenderId : new Nullable<int>(); } set { GenderId = (value ?? 0); } }


        [DisplayName("رقم الهويه")]
        public string SId { get; set; }
        [DisplayName("المعرف")]
        public int Id { get; set; }



    }

    public class CreateCustomersCommand : IRequest<int>
    {

        [DisplayName("المدينه")]
        public string CityName { get; set; }

        [DisplayName("المحافظه")]
        public string StateName { get; set; }

        [DisplayName("المحافظه")]
        public int StateId { get; set; }
        [DisplayName("الجنس")]
        public int GenderId { get; set; }
        [DisplayName("الجنس")]
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


    }

    public class CreateCustomersFMValidator : CreateCustomersCommandValidator<CreateCustomersFM>
    {
        public CreateCustomersFMValidator()
        {


        }
    }

    public class CreateCustomersCommandValidator : CreateCustomersCommandValidator<CreateCustomersCommand>
    {
    }
    public class CreateCustomersCommandValidator<T> : AbstractValidator<T> where T : CreateCustomersCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public CreateCustomersCommandValidator()
        {

            RuleFor(v => v.CityId).NotEmpty();
            RuleFor(v => v.StateId).NotEmpty();
            RuleFor(v => v.NameAr).NotEmpty();
            RuleFor(v => v.NameEn).NotEmpty();
            RuleFor(v => v.Phone).NotEmpty();
            RuleFor(v => v.Address).NotEmpty();
            RuleFor(v => v.GenderId).NotEmpty();
            RuleFor(v => v.Age).NotEmpty();



        }
    }


}

