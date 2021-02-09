using System;
using MediatR;
using AutoMapper;
using System.Net.Http;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Shipping.Domain.Entities;
using Shipping.Domain.Enums;
using eServices.Shared;

namespace Shared.Commands
{
    public class UserBasicInfo:IMapFrom<User>
    {
        [DisplayName("رقم الهويه")]
        public string SId { get; set; }
        [DisplayName("المعرف")]
        public int Id { get; set; }
        [DisplayName("الاسم بالعربي")]
        public string NameAr { get; set; }
        [DisplayName("الاسم بالانجليزي")]
        public string NameEn { get; set; }
        public UserType Type { get; set; }
    }

}
