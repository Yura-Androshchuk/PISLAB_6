using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class Dish
    {
        public Guid DishId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Invalid length")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
        public double TimeInSec { get; set; }

        
    
        public virtual IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
