using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BlDto
{
    public class BlDto_Dish
    {
        public Guid DishId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double TimeInSec { get; set; }
        public Guid OrderID { get; set; }
     
    }
}
