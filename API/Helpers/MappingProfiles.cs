using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Infrastucture.Data.Config;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles(){
            CreateMap<ProductModel, ProductToReturnDto>()
            .ForMember(d=> d.CampCity , o=> o.MapFrom(s=> s.CampCity.Name))
            .ForMember(d => d.PictureUrl , o=> o.MapFrom<ProductUrlResolver>());
        }   
    }
}