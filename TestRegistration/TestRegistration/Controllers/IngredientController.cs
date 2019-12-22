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
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        public class DishController : ControllerBase
        {
            private IMapper mapper;
            private ILoggerManager _logger;
            private IIngredientService ingredientService;

            public DishController(ILoggerManager logger, IIngredientService ingredientService, IMapper mapper)
            {
                _logger = logger;
                //_repository = repository;
                this.mapper = mapper;
                this.ingredientService = ingredientService;
            }

            // GET: api/DishesControllerTest
            [HttpGet]
            public IActionResult GetIngredients()
            {
                var ingredients = ingredientService.GetAllIngredients();
                if (ingredients == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mapper.Map<IEnumerable<IngredientPlDto>>(ingredients));
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
            public IActionResult PutIngredient(Guid id, [FromBody] IngredientPlDto ingredient)
            {
                if (id != ingredient.IngredientId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Model is not valid");
                }

                try
                {
                    ingredient.IngredientId = id;
                    var newingredient = mapper.Map<BlDto_Ingredient>(ingredient);
                    ingredientService.UpdateIngredient(newingredient);
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
            public IActionResult PostDish([FromBody] IngredientPlDto ingredient)
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Model is not valid");
                }

                try
                {
                    ingredient.IngredientId = Guid.NewGuid();
                    var newIngredient = mapper.Map<BlDto_Ingredient>(ingredient);
                    ingredientService.AddIngredient(newIngredient);

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
            public IActionResult DeleteDish(Guid id, [FromBody] IngredientPlDto ingredient)
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Model is not valid");
                }

                try
                {
                    ingredient.IngredientId = id;
                    var newDish = mapper.Map<BlDto_Ingredient>(ingredient);
                    ingredientService.DeleteIngredient(newDish);
                    return StatusCode(204, "Author was deleted");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error. Author is not deleted. Exception message: " + ex);
                }
            }

        }
    }
}