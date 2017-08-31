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
            CreateMap<StatEntity, Statistics>()
                .ForMember(dest => dest.Stat, opt => opt.MapFrom(src => src.Stat));
        }
    }
}
