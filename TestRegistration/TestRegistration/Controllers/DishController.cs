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

        // GET: api/DishesControllerTest
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

        // PUT: api/DishesControllerTest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
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
                return StatusCode(204, "Author was deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Author is not deleted. Exception message: " + ex);
            }
        }

        // POST: api/DishesControllerTest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
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

                return StatusCode(201, "Author was added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Author is not added. Exception message: " + ex);
            }



            //  return CreatedAtAction("GetDish", new { id = dish.DishId }, dish);
        }

        // DELETE: api/DishesControllerTest/5
        [HttpDelete("{id}")]
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
                return StatusCode(204, "Author was deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Author is not deleted. Exception message: " + ex);
            }
        }

    }
}