using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRegistration.DtosPL
{
    public class IngredientPlDto
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public Guid DishId { get; set; }
    }
}
