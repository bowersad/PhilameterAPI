using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhilameterAPI.Models;

namespace PhilameterAPI.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StatisticEntity, Statistic>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value / 100m));
        }
    }
}
