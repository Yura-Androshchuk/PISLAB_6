using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class Ingredient
    {
        public Guid IngredientId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Invalid length")]
        public string Name { get; set; }

        [ForeignKey(nameof(Dish))]
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }

    }
}
