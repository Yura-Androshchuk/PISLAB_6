using AutoMapper;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.BlDto;

namespace TestRegistration.Mapping
{
    public class BisnessLogicMapping: Profile
    {
        public BisnessLogicMapping()
        {
            CreateMap<Dish, BlDto_Dish>();
            CreateMap<Order, BlDto_Order>();
            CreateMap<Ingredient, BlDto_Ingredient>();
        }
    }
}
