using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRegistration.DtosPL
{
    public class DishPlDto
    {
        public Guid DishId { get; set; }

        public string Name { get; set; }

        public double TimeInSec { get; set; }
        public double Price { get; set; }
    }
}
