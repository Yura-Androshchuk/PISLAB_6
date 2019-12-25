using AutoMapper;
using BusinessLogic.BlDto;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRegistration.DtosPL;

namespace TestRegistration.Mappers
{
    public class MappingProfileBll : Profile
    {
        public MappingProfileBll()
        {
            CreateMap<BlDto_Dish,Dish>().ReverseMap();
            CreateMap<BlDto_Order,Order>().ReverseMap();
            CreateMap<BlDto_Ingredient,Ingredient>().ReverseMap();
        }
    }
}
