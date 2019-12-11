using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
    public class Dish
    {
        public Guid DishId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        [ForeignKey(nameof(Dish))]
        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
        public virtual IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
