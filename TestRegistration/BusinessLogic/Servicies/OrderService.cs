using AutoMapper;
using BusinessLogic.BlDto;
using BusinessLogic.Interfaces;
using Dal.Interfaces;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Servicies
{
    public class OrderService : IOrderService
    {
        private IMapper mapper;
        private IRepositoryWrapper wrapper;

        public OrderService(IMapper mapper, IRepositoryWrapper wrapper)
        {
            this.mapper = mapper;
            this.wrapper = wrapper;

        }

        public IEnumerable<BlDto_Order> GetAllOrders()
        {
            var orders = wrapper.Order.FindAll().ToList();
            return mapper.Map<IEnumerable<BlDto_Order>>(orders);
        }

        public void AddOrder(BlDto_Order order)
        {
            var newOrder = mapper.Map<Dal.Models.Order>(order);
            wrapper.Order.Create(newOrder);
            wrapper.Save();
        }
        public void UpdateOrder(BlDto_Order order)
        {
            var newOrder = mapper.Map<Dal.Models.Order>(order);
            wrapper.Order.Update(newOrder);
            wrapper.Save();
        }

        public void DeleteOrder(BlDto_Order order)
        {
            var newOrder = mapper.Map<Dal.Models.Order>(order);
            wrapper.Order.Delete(newOrder);
            wrapper.Save();
        }
    }
}
