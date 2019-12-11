using AutoMapper;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRegistration.DtosPL;

namespace TestRegistration.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dish, DishPlDto>();
        }
    }
}
