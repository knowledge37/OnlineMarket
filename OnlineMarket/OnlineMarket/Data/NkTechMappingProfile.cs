using AutoMapper;
using DutchTreat.Data.Entities;
using OnlineMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Data
{
    public class NkTechMappingProfile: Profile
    {
            public NkTechMappingProfile()
        {

            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id));

            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
        }
    }
}
