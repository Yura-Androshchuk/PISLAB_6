using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Interfaces
{
    public interface IRepositoryWrapper
    {
        IDishRepository Dish { get; }
        IOrderRepository Order { get; }
        IIngredientRepository Ingredient { get; }
        void Save();
    }
}
