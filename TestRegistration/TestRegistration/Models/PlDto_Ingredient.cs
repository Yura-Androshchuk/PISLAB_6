using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRegistration.Models
{
    public class PlDto_Ingredient
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public Guid DishId { get; set; }
    }
}
