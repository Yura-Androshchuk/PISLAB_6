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
    [Route("api/ingredient")]
    [ApiController]
   
        public class IngredientController : ControllerBase
        {
            private IMapper mapper;
            private ILoggerManager _logger;
            private IIngredientService ingredientService;

            public IngredientController(ILoggerManager logger, IIngredientService ingredientService, IMapper mapper)
            {
                _logger = logger;
                //_repository = repository;
                this.mapper = mapper;
                this.ingredientService = ingredientService;
            }
        /// <summary>
        /// Gets the list of all Ingredients.
        /// </summary>
        /// <returns>The list of Ingredients.</returns>
        // GET: api/IngredientController
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

        /// <summary>
        /// Update an Ingredient.
        /// </summary>
        /// <returns>Status code</returns>
        /// <response code="204">Ingredient successfully updated</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">Server Error</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Creates an Ingredient.
        /// </summary>
        /// <returns>A newly created ingredient</returns>

        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        ///  <response code="500">Server Error</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult PostIngredient([FromBody] IngredientPlDto ingredient)
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



                
            }
        /// <summary>
        /// Delete an Ingredient.
        /// </summary>
        /// <returns>Status code</returns>

        /// <response code="204">Ingredient successfully deleted</response>
        /// <response code="400">If the item is null</response>
        /// /// <response code="500">Server Error</response> 

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult DeleteIngredient(Guid id, [FromBody] IngredientPlDto ingredient)
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