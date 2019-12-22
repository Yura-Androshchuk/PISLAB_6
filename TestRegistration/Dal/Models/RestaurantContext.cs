using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class RestaurantContext: DbContext
    {
        private string connection;
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {

        }
        public RestaurantContext(string connection)
        {
            this.connection = connection;
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
