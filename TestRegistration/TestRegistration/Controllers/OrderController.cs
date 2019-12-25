using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.BlDto;
using BusinessLogic.Interfaces;
using Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestRegistration.DtosPL;

namespace TestRegistration.Controllers
{
    [Route("api/order")]
    [ApiController]
   
        public class OrderController : ControllerBase
        {
            private IMapper mapper;
            private ILoggerManager _logger;
            private IOrderService orderService;

            public OrderController(ILoggerManager logger, IOrderService orderService, IMapper mapper)
            {
                _logger = logger;
                //_repository = repository;
                this.mapper = mapper;
                this.orderService = orderService;
            }
            /// <summary>
            /// Gets the list of all Orders.
            /// </summary>
            /// <returns>The list of orders.</returns>
            // GET: api/OrderController
            
            [HttpGet]
            public IActionResult GetOrders()
            {
                var orders = orderService.GetAllOrders();
                if (orders == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mapper.Map<IEnumerable<OrderPlDto>>(orders));
                }
            }



        /// <summary>
        /// Update a Order.
        /// </summary>
        /// <returns>Status code</returns>
        /// <response code="204">Order successfully updated</response>
        /// <response code="400">If the item is null</response>
        /// /// <response code="500">Server Error</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult PutOrder(Guid id, [FromBody] OrderPlDto order)
            {
                if (id != order.OrderId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Model is not valid");
                }

                try
                {
                    order.OrderId = id;
                    var newOrder = mapper.Map<BlDto_Order>(order);
                    orderService.UpdateOrder(newOrder);
                    return StatusCode(204, "Order was deleted");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error. Order is not deleted. Exception message: " + ex);
                }
            }

        /// <summary>
        /// Creates an Order.
        /// </summary>
        /// <returns>A newly created order</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// /// <response code="500">Server Error</response> 
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult PostOrder([FromBody] OrderPlDto order)
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Model is not valid");
                }

                try
                {
                    order.OrderId = Guid.NewGuid();
                    var newOrder = mapper.Map<BlDto_Order>(order);
                    orderService.AddOrder(newOrder);

                    return StatusCode(201, "Order was added");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error. Order is not added. Exception message: " + ex);
                }



                //  return CreatedAtAction("GetDish", new { id = dish.DishId }, dish);
            }

        /// <summary>
        /// Delete an order.
        /// </summary>
        /// <returns>Status code</returns>

        /// <response code="204">Order successfully deleted</response>
        /// <response code="400">If the item is null</response>
        /// /// <response code="500">Server Error</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult DeleteOrder(Guid id, [FromBody] OrderPlDto order)
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Model is not valid");
                }

                try
                {
                    order.OrderId = id;
                    var newOrder = mapper.Map<BlDto_Order>(order);
                    orderService.DeleteOrder(newOrder);
                    return StatusCode(204, "Order was deleted");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error. Order is not deleted. Exception message: " + ex);
                }
            }

        }
    
}