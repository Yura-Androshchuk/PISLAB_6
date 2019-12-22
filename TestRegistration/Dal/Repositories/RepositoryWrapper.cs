using Dal.Interfaces;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories
{
     public class RepositoryWrapper: IRepositoryWrapper
    {
        private RestaurantContext _restaurantContext;
        private IDishRepository _dish;
        private IOrderRepository _order;
        private IIngredientRepository _ingredient;

        public RepositoryWrapper(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }
        public RepositoryWrapper(string connection)
        {
            this._restaurantContext = new RestaurantContext(connection);
        }
        public void Save()
        {
            _restaurantContext.SaveChanges();
        }
        public IDishRepository Dish
        {
            get
            {
                if (_dish == null)
                {
                    _dish = new DishRepository(_restaurantContext);
                }

                return _dish;
            }
        }

        public IOrderRepository Order 
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_restaurantContext);
                }

                return _order;
            }
        }

        public IIngredientRepository Ingredient
        {
            get
            {
                if (_ingredient == null)
                {
                    _ingredient = new IngredientRepository(_restaurantContext);
                }

                return _ingredient;
            }
        }



    }
}
