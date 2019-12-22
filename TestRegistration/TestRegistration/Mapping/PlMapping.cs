using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.BlDto;
using TestRegistration.Models;
namespace TestRegistration.Mapping
{
    public class PlMapping: Profile
    {
        public PlMapping()
        {
            CreateMap<BlDto_Dish, PlDto_Dish>();
            CreateMap<BlDto_Ingredient, PlDto_Ingredient>();
            CreateMap<BlDto_Order, PlDto_Order>();
        }
    }
}
