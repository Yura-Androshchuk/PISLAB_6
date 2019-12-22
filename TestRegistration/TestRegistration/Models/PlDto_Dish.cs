using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRegistration.Models
{
    public class PlDto_Dish
    {
        public Guid DishId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Guid OrderID { get; set; }
    }
}
