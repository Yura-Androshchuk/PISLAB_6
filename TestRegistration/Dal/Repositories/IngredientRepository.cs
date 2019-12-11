using Dal.Interfaces;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories
{
    public class IngredientRepository:RepositoryBase<Ingredient>,IIngredientRepository
    {
        public IngredientRepository(RestaurantContext restaurantContext):base(restaurantContext)
        {

        }
    }
}
