using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private IMapper _mapper;
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public DishController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllODishes()
        {
            try
            {
                var dishes = _repository.Dish.GetAllDishes();

                _logger.LogInfo($"Returned all owners from database.");

                var dishResult = _mapper.Map<IEnumerable<DishPlDto>>(dishes);
                return Ok(dishResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}