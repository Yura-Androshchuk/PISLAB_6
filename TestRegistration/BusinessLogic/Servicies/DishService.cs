using BusinessLogic.Interfaces;
using System;
using Dal.Repositories;
using AutoMapper;
using BusinessLogic.BlDto;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dal.Interfaces;

namespace BusinessLogic.Servicies
{
    public class DishService: IDishService
    {
        private IMapper mapper;
        private RepositoryWrapper wrapper;
        public DishService(IMapper mapper, RepositoryWrapper wrapper)
        {
            this.mapper = mapper;
            this.wrapper = wrapper;
        }

        public IEnumerable<BlDto_Dish> GetAllDishes()
        {
            var dish = wrapper.Dish.FindAll().ToList();
            return mapper.Map<IEnumerable<BlDto_Dish>>(dish);
        }
        public void AddDish(BlDto_Dish dish)
        {
            var book = mapper.Map<Dal.Models.Dish>(dish);
            wrapper.Dish.Create(book);
            wrapper.Save();
        }
        public void UpdateDish(BlDto_Dish dish)
        {
            var book = mapper.Map<Dal.Models.Dish>(dish);
            wrapper.Dish.Update(book);
            wrapper.Save();
        }
        public void DeleteDish(BlDto_Dish dish)
        {
            var book = mapper.Map<Dal.Models.Dish>(dish);
            wrapper.Dish.Delete(book);
            wrapper.Save();
        }
    }
}
