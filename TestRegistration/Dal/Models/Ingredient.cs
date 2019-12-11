using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class Ingredient
    {
        public Guid IngredientId { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(Dish))]
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }

    }
}
