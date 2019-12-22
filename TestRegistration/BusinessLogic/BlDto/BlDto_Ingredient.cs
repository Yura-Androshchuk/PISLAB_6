using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BlDto
{
   public  class BlDto_Ingredient
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public Guid DishId { get; set; }
    }
}
