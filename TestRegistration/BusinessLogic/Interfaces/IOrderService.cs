using BusinessLogic.BlDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface  IOrderService
    {
        IEnumerable<BlDto_Order> GetAllOrders();

        void AddOrder(BlDto_Order order);
        void UpdateOrder(BlDto_Order order);
        void DeleteOrder(BlDto_Order order);
    }
}
