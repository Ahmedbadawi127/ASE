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
    public class UpdateStateFM : UpdateStateCommand
    {


    }

    public class UpdateStateCommand : IRequest<int>
    {

        [DisplayName("المعرف")]
        public int Id { get; set; }

        [DisplayName("المحافظه")]
        public string Name { get; set; }

    }

    public class UpdateStateFMValidator : UpdateStateCommandValidator<UpdateStateFM>
    {
        public UpdateStateFMValidator()
        {


        }
    }

    public class UpdateStateCommandValidator : UpdateStateCommandValidator<UpdateStateCommand>
    {
    }
    public class UpdateStateCommandValidator<T> : AbstractValidator<T> where T : UpdateStateCommand
    {
        protected DateTime DateNullValue = DateTime.Parse("4-30-1900");
        public UpdateStateCommandValidator()
        {

            RuleFor(v => v.Name).NotEmpty().WithName(ReflectionExtensions.GetPropertyDisplayName<CreateStateCommand>(i => i.Name));


        }
    }


}

