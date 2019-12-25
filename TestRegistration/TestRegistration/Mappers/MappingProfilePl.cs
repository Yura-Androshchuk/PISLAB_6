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
    public class MappingProfilePl:Profile
    {
        public MappingProfilePl()
        {
            CreateMap<BlDto_Dish, DishPlDto>().ReverseMap();
            CreateMap<BlDto_Order, OrderPlDto>().ReverseMap();
            CreateMap<BlDto_Ingredient, IngredientPlDto>().ReverseMap();
        }
    }
}
