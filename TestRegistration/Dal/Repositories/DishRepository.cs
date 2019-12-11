using Dal.Interfaces;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal.Repositories
{
    public class DishRepository: RepositoryBase<Dish>,IDishRepository
    {
        public DishRepository(RestaurantContext restaurantContext):base(restaurantContext)
        {
        }
        public IEnumerable<Dish> GetAllDishes()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }
    }
}
