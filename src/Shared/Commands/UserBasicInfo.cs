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
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Shipping.Domain.Entities;

namespace Shipping.Shared.Commands
{
    public class UserBasicInfo:IMapFrom<User>
    {
        [DisplayName("رقم الهويه")]
        public string SId { get; set; }
        [DisplayName("المعرف")]
        public int Id { get; set; }
        [DisplayName("الإسم بالعربي")]
        public string NameAr { get; set; }
        [DisplayName("الإسم بالانجليزي")]
        public string NameEn { get; set; }
        [DisplayName("النوع")]
        public int TypeId { get; set; }
        [DisplayName("النوع")]
        public string TypeName { get; set; }


    }

}
