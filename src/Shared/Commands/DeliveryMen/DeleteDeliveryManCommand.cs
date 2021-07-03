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

namespace Shipping.Shared.Commands.DeliveryMen
{

    public class DeleteDeliveryManCommand : IRequest<int>
    {

        [DisplayName("المعرف")]
        public int Id { get; set; }

    }

}

