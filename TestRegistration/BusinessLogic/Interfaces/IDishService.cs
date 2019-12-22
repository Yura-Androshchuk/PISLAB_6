using BusinessLogic.BlDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IDishService
    {
        IEnumerable<BlDto_Dish> GetAllDishes();
        //IEnumerable<BlDto_Dish> GetAllDishesByName();

        void AddDish(BlDto_Dish dish);
        void UpdateDish(BlDto_Dish dish);
        void DeleteDish(BlDto_Dish dish);
    }
}
