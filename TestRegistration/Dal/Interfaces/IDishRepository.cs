using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Interfaces
{
    public interface IDishRepository: IRepositoryBase<Dish>
    {
        IEnumerable<Dish> GetAllDishes();
    }
}
