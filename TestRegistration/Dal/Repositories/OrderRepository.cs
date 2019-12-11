using Dal.Interfaces;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories
{
    public class OrderRepository:RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantContext restaurantContext):base(restaurantContext)
        {
                
        }
    }
}
