using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.BlDto;
using BusinessLogic.Interfaces;
using Dal;
using Dal.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestRegistration.DtosPL;

namespace TestRegistration.Controllers
{
    [Route("api/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private IMapper mapper;
        private ILoggerManager _logger;
        private IDishService dishService;

        public DishController(ILoggerManager logger, IDishService dishService, IMapper mapper)
        {
            _logger = logger;
            //_repository = repository;
            this.mapper = mapper;
            this.dishService = dishService;
        }

        /// <summary>
        /// Gets the list of all Dishes.
        /// </summary>
        /// <returns>The list of Dishes.</returns>
        // GET: api/DishesController
        [HttpGet]
        public IActionResult GetDishes()
        {
            var dishes = dishService.GetAllDishes();
            if (dishes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<IEnumerable<DishPlDto>>(dishes));
            }
        }

        // GET: api/DishesControllerTest/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Dish>> GetDish(Guid id)
        //{
        //    var dish = await _context.Dishes.FindAsync(id);

        //    if (dish == null)
        //    {
        //        return NotFound();
        //    }

        //    return dish;
        //}

        /// <summary>
        /// Update a dish.
        /// </summary>
        /// <returns>Status code</returns>
        /// <response code="204">Dish successfully updated</response>
        /// <response code="400">If the item is null</response>
        ///  <response code="500">Server Error</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult PutDish(Guid id, [FromBody] DishPlDto dish)
        {
            if (id != dish.DishId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                dish.DishId = id;
                var newdish = mapper.Map<BlDto_Dish>(dish);
                dishService.UpdateDish(newdish);
                return StatusCode(204, "Dish was updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Dish is not deleted. Exception message: " + ex);
            }
        }

        /// <summary>
        /// Creates a Dish.
        /// </summary>
        /// <returns>A newly created dish</returns>

        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// /// <response code="500">Server Error</response>     
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult PostDish([FromBody] DishPlDto dish)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                dish.DishId = Guid.NewGuid();
                var newDish = mapper.Map<BlDto_Dish>(dish);
                dishService.AddDish(newDish);

                return StatusCode(201, "Dish was added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Dish is not added. Exception message: " + ex);
            }



            //  return CreatedAtAction("GetDish", new { id = dish.DishId }, dish);
        }
        /// <summary>
        /// Delete a dish.
        /// </summary>
        /// <returns>Status code</returns>

        /// <response code="204">Dish successfully deleted</response>
        /// <response code="400">If the item is null</response>
        /// /// <response code="500">Server Error</response>   
        
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult DeleteDish(Guid id, [FromBody] DishPlDto dish)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                dish.DishId = id;
                var newDish = mapper.Map<BlDto_Dish>(dish);
                dishService.DeleteDish(newDish);
                return StatusCode(204, "Dish was deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Dish is not deleted. Exception message: " + ex);
            }
        }

    }
}