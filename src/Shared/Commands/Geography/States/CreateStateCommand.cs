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

namespace Shipping.Shared.Commands.Geography.States
{
    public class CreateStateFM : CreateStateCommand
    {


    }

    public class CreateStateCommand : IRequest<int>
    {

        [DisplayName("المعرف")]
        public int Id { get; set; }

        [DisplayName("المحافظه")]
        public string Name { get; set; }

    }

    public class CreateStateFMValidator : CreateStateCommandValidator<CreateStateFM>
    {
        public CreateStateFMValidator()
        {


        }
    }

    public class CreateStateCommandValidator : CreateStateCommandValidator<CreateStateCommand>
    {
    }
    public class CreateStateCommandValidator<T> : AbstractValidator<T> where T : CreateStateCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public CreateStateCommandValidator()
        {

            RuleFor(v => v.Name).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateStateCommand>(i => i.Name));

        }
    }


}

